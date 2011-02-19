using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using GameDev.Input;
using GameDev.Utils;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace GameDev.Scenes
{
    public class SceneScheduler : GameComponent
    {

        public SceneScheduler() : base(GameDevGame.Current)
        {
        }

        private Dictionary<Scene, List<SceneChange>> m_SceneChanges = new Dictionary<Scene,List<SceneChange>>();

        public void AddSceneChange(SceneChange sceneChange)
        {
            if (CurrentScene == null)
            {
                CurrentScene = sceneChange.From;
            }
            if (m_SceneChanges.ContainsKey(sceneChange.From))
            {
                m_SceneChanges[sceneChange.From].Add(sceneChange);
            }
            else
            {
                m_SceneChanges.Add(sceneChange.From, new List<SceneChange>() { sceneChange });
            }
        }

        private Scene m_CurrentScene;
        public Scene CurrentScene
        {
            get
            {
                return m_CurrentScene;
            }
            set
            {
                m_CurrentScene.Disable();
                m_CurrentScene = value;
                m_CurrentScene.Enable();
            }
        }

        private static Scene m_NextScene;
        public static Scene NextScene
        {
            get
            {
                return m_NextScene;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (m_SceneChanges.ContainsKey(CurrentScene))
            {
                foreach (SceneChange sc in m_SceneChanges[CurrentScene])
                {
                    if (sc.ChangeNow(gameTime))
                    {
                        m_NextScene = sc.To;
                        if (CurrentScene != null)
                        {
                            CurrentScene.OnExit();
                            StopMainTune(m_NextScene);
                            CurrentScene.StopTune();
                        }
                        CurrentScene = m_NextScene;
                        CurrentScene.StartTime = gameTime.TotalRealTime();
                        CurrentScene.Reset();
                        CurrentScene.OnEnter();
                        CurrentScene.StartTune();
                        StartMainTune();
                    }
                }
            }
        }

        private void StopMainTune(Scene nextScene)
        {
            if (IsMainTunePlaying && ((CurrentScene == null || CurrentScene.SceneTune == null) && (nextScene == null || nextScene.SceneTune != null)))
            {
                MediaPlayer.Stop();
                IsMainTunePlaying = false;
            }
        }

        public Song MainTune { get; set; }
        public bool IsMainTunePlaying { get; set; }


        private void StartMainTune()
        {
            if (!IsMainTunePlaying && (CurrentScene == null || CurrentScene.SceneTune == null))
            {
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(MainTune);
                MediaPlayer.Volume = 0.1f;
                IsMainTunePlaying = true;
            }
        }

    }
}
