﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DxCrm.Classes;
using MongoDB.Driver;

namespace DxCrm
{
    static class Program
    {
        private static MainForm mainForm;
        private static readonly ApplicationSettings appSettings = ApplicationSettings.Instance;
        //private static IMongoDatabase crmDb;

        public static MainForm MainForm { get { return Program.mainForm; } }
        public static ApplicationSettings AppSettings { get { return appSettings; } }
        //public static IMongoDatabase CrmDb { get { return crmDb; } }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            appSettings.Read();

            //crmDb = new MongoClient(new MongoClientSettings
            //{
            //    Server = new MongoServerAddress(appSettings.Host, appSettings.Port),
            //    UseSsl = false
            //}).GetDatabase(appSettings.Database);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();

            
            Program.mainForm = new MainForm();

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = AppSettings.Theme;

            Application.Run(Program.mainForm);
            //Application.Run(new MainForm());
        }
    }
}