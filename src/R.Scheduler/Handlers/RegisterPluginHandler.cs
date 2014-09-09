﻿using System.Reflection;
using log4net;
using R.MessageBus.Interfaces;
using R.Scheduler.Contracts.Messages;
using R.Scheduler.Interfaces;

namespace R.Scheduler.Handlers
{
    public class RegisterPluginHandler : IMessageHandler<RegisterPlugin>
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        readonly ISchedulerCore _schedulerCore;

        public RegisterPluginHandler(ISchedulerCore schedulerCore)
        {
            _schedulerCore = schedulerCore;
        }

        public void Execute(RegisterPlugin command)
        {
            Logger.InfoFormat("Entered RegisterPluginHandler.Execute(). PluginName = {0}", command.PluginName);

            _schedulerCore.RegisterPlugin(command.PluginName, command.AssemblyPath);
        }

        public IConsumeContext Context { get; set; }
    }
}
