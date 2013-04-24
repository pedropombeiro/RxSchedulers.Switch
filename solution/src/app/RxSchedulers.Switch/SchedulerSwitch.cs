// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SchedulerSwitch.cs" company="Pedro Pombeiro">
//   © 2012-2013 Pedro Pombeiro. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RxSchedulers.Switch
{
    using System;
    using System.Reactive.Concurrency;

    /// <summary>
    /// The Rx scheduler switch. This class provides a redirection point for the system schedulers, allowing them to be easily replaced (e.g. for testing purposes).
    /// </summary>
    public static class SchedulerSwitch
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="SchedulerSwitch"/> class.
        /// </summary>
        static SchedulerSwitch()
        {
            SchedulerSwitch.GetImmediateScheduler = () => Scheduler.Immediate;
            SchedulerSwitch.GetDispatcherScheduler = () => DispatcherScheduler.Current;
            SchedulerSwitch.GetTaskPoolScheduler = () => TaskPoolScheduler.Default;
            SchedulerSwitch.GetCurrentThreadScheduler = () => CurrentThreadScheduler.Instance;
            SchedulerSwitch.GetNewThreadScheduler = () => NewThreadScheduler.Default;
            SchedulerSwitch.GetThreadPoolScheduler = () => ThreadPoolScheduler.Instance;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the current thread scheduler (normally <see cref="CurrentThreadScheduler.Instance"/>).
        /// </summary>
        public static Func<IScheduler> GetCurrentThreadScheduler { get; set; }

        /// <summary>
        /// Gets or sets the dispatcher scheduler (normally <see cref="DispatcherScheduler.Current"/>).
        /// </summary>
        public static Func<IScheduler> GetDispatcherScheduler { get; set; }

        /// <summary>
        /// Gets or sets the get immediate scheduler (normally <see cref="Scheduler.Immediate"/>).
        /// </summary>
        public static Func<IScheduler> GetImmediateScheduler { get; set; }

        /// <summary>
        /// Gets or sets the get new thread scheduler (normally <see cref="NewThreadScheduler.Default"/>).
        /// </summary>
        public static Func<IScheduler> GetNewThreadScheduler { get; set; }

        /// <summary>
        /// Gets or sets the task pool scheduler (normally <see cref="TaskPoolScheduler.Default"/>).
        /// </summary>
        public static Func<IScheduler> GetTaskPoolScheduler { get; set; }

        /// <summary>
        /// Gets or sets the thread pool scheduler (normally <see cref="TaskPoolScheduler.Default"/>).
        /// </summary>
        public static Func<IScheduler> GetThreadPoolScheduler { get; set; }

        #endregion
    }
}