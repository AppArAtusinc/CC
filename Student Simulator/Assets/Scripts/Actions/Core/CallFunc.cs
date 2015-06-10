using System;

namespace Actions.Core
{
	/// <summary>
	/// Action which using for calling diffrent function in action sequence.
	/// </summary>
	class CallFunction: GameAction
	{
		/// <summary>
		/// Function for calling.
		/// </summary>
		public Action function;

		/// <summary>
		/// Create action which call function.
		/// </summary>
		/// <param name="Function"> Function for calling. </param>
		public CallFunction(Action Function)
		{
			function = Function;
		}

		/// <summary>
		/// Call function on frame.
		/// </summary>
		/// <param name="Delta"> Not use. </param>
		/// <returns>
		/// Return only false, because need call only once.
		/// </returns>
		public override bool Upadate (float Delta)
		{
			function();
			return false;
		}
	}

}