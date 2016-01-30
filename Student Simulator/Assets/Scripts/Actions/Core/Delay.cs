using StudentSimulator.SaveSystem;
using System;

namespace Actions.Core
{
	/// <summary>
	/// Stop sequence for some time.
	/// </summary>
	class Delay : GameAction
	{
		/// <summary>
		/// Total time for waiting.
		/// </summary>
        /// <owner>Stanislav Silin</owner>
        [Save]
        public float totalDelay;

		/// <summary>
		/// Current waiting time.
		/// </summary>
        /// <owner>Stanislav Silin</owner>
        [Save]
        public float currentDelay;

		public Delay(){}

        /// <summary>
        /// Creating action which stop action sequence for some time. 
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        /// <param name="Delay"> Time for waiting. One second == 1.0 </param>
        public Delay (float Delay)
		{
			totalDelay = Delay;
			currentDelay = 0;
		}

        /// <summary>
        /// Reset current time to zero.
        /// <owner>Stanislav Silin</owner>
        /// </summary>
        public override void Start()
		{
            base.Start();
            currentDelay = 0;
		}

        /// <summary>
        /// Calling each frame.
        /// </summary>
        /// <owner>Stanislav Silin</owner>
        /// <param name="delta"> Time from last call.</param>
        protected override void Tick(float delta)
		{
            if (currentDelay > totalDelay)
                Finish();

			currentDelay += delta;
		}
	}
}

