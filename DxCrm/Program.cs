﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DxCrm.Classes;
using MongoDB.Driver;
using System.IO;

namespace DxCrm
{
    static class Program
    {
        private static MainForm mainForm;
        private static readonly ApplicationSettings appSettings = ApplicationSettings.Instance;
        

        public static MainForm MainForm { get { return Program.mainForm; } }
        public static ApplicationSettings AppSettings { get { return appSettings; } }
        public const string GRID_LAYOUTS_DIR = "GridLayouts";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            appSettings.Read();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();

            string directory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, GRID_LAYOUTS_DIR);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            Program.mainForm = new MainForm();

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = AppSettings.Theme;

            try
            {
                Application.Run(Program.mainForm);
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, ex.Message);
            }
        }
    }
}
