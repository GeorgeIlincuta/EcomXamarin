﻿using EcomXamarin.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcomXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SignupPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}