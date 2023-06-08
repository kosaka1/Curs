﻿using System.Media;


namespace Cursovoi
{
    internal class Engine // відповідає за ігровий процес
    {
        public bool IsPlaying = true;
        public bool IsPause = false;
        public GameResult GameResult;
        public (int x, int y) BonusPosition;
        private SoundPlayer soundPlayer = new SoundPlayer();
        private Map map;
        private Pacman pacman;
        private Enemy[] enemies;
        private bool isBonusLevel = false;
        private ConsoleKey key;

        public Engine(Map map, Pacman pacman, Enemy[] enemies)
        {
            this.map = map;
            if (this.map.Name.ToLower().Contains("bonus"))
            {
                isBonusLevel = true;
            }
            this.pacman = pacman;
            if (this.pacman.X == 0 && this.pacman.Y == 0)
            {
                IsPlaying = false;
            }
            this.enemies = enemies;
            keyChanged += HandleKey;
            GameResult = GameResult.None;
        }

        private void HandleKey(ConsoleKey key)
        {
            if (IsPause)
            {
                IsPause = false;
                if (Settings.MusicIsOn) soundPlayer.Play();
                return;
            }
            switch (this.key)
            {
                case ConsoleKey.M:
                    IsPlaying = false;
                    break;
                case ConsoleKey.Spacebar:
                    IsPause = true;
                    if (Settings.MusicIsOn) soundPlayer.Stop();  
                    break;
            }
        }

        public void Start()
        {
            soundPlayer.SoundLocation = "Music/gamePacMan.wav";
            if (Settings.MusicIsOn) soundPlayer.PlayLooping();
            if (isBonusLevel)
            {
                AppearingBonus appearingBonus = new AppearingBonus(map);
                Task.Run(() =>
                {
                    while (IsPlaying)
                    {
                        if (!IsPause && map.Count(new Dollar()) <= 10)
                        {
                            BonusPosition = appearingBonus.Appear();
                        }
                        Thread.Sleep(4850);
                    }
                });
            }
            Task.Run(() =>
            {
                while (IsPlaying)
                {
                    if (IsPause)
                    {
                        continue;
                    }
                    foreach (Enemy enemy in enemies)
                    {
                        pacman.CheckPosition(enemy);
                        enemy.Move(pacman.X, pacman.Y);
                        pacman.CheckPosition(enemy);
                    }
                    pacman.Move(key);
                    Thread.Sleep((int)(240 * Settings.GameSpeed));
                }
            });
            Task.Run(() =>
            {
                while (IsPlaying)
                {
                    if (pacman.HealthPoints <= 0)
                    {
                        Lose(ref IsPlaying);
                    }
                    else if (!isBonusLevel && map.NeedableCoins == Pacman.PickedCoins)
                    {
                        Win(ref IsPlaying);
                    }
                    Thread.Sleep((int)(180 * Settings.GameSpeed));
                }
            });
        }

        public void PressKey(ConsoleKey key)
        {
            this.key = key;
            keyChanged?.Invoke(key);
        }

        private void Lose(ref bool isPlaying)
        {
            isPlaying = false;
            GameResult = GameResult.Lose;
        }

        private void Win(ref bool isPlaying)
        {
            isPlaying = false;
            GameResult = GameResult.Win;
        }

        private delegate void KeyHandler(ConsoleKey key);
        event KeyHandler keyChanged;
    }
}
