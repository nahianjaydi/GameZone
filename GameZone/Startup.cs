﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameZone.Startup))]
namespace GameZone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
