using System;

using UnityEngine;

//This was coded by Joseph Burchett josephburchett@yahoo.com
namespace Utils
{
	/// <summary>
	/// This is a utility class used for creating a sort of stop watch.
	/// Can be used to execute a chunk of code based on an increment of time.
	/// </summary>
	/// 
	/// <example>
	/// This is a short example of how to use the timer in a unity script
	/// <code>
	/// 
	/// public Timer timer;
	/// 
	/// void Start()
	/// {
	/// 	Timer = new Timer( 1000 );
	/// 	timer.tick += delegate( System.Object o, System.EventArgs e ) { print( "it ticked" ); };
	/// 	timer.Start();
	/// }
	/// 
	/// void Update()
	/// {
	/// 	timer.Update();
	/// }
	/// 
	/// </code>
	/// </example>
	public class Timer
	{
		/// <summary>
		/// This will hold the amount of seconds the timer
		/// will run for. This value is set in the constuctor.
		/// <see cref="Utils.Timer.Timer( int milliseconds )" />
		/// </summary>
		protected int _secondsToPass;
		
		/// <summary>
		/// This will keep track of whether or not the timer has
		/// been started.
		/// <see cref="Utils.Timer.Start()" />
		/// </summary>
		protected bool _started;
		
		/// <summary>
		/// This is used to keep track of what is currently being count down.
		/// <see cref="Utils.timer.Update()" />
		/// </summary>
		protected bool _ticking;
		
		/// <summary>
		/// This represents the amount of seconds that need to be
		/// reached before the tick event can be fired.
		/// </summary>
		protected float _timeToReach;
		
		/// <summary>
		/// Gets a value indicating whether this <see cref="Utils.Timer"/> is started.
		/// </summary>
		/// <value>
		/// <c>true</c> if started; otherwise, <c>false</c>.
		/// </value>
		public bool started
		{
			get { return _started; }	
		}
		
		/// <summary>
		/// The delegate that will hold all the references to the
		/// methods that will be listening, for the tick event.
		/// </summary>
		public delegate  void tickEventHandler( System.Object o, EventArgs e );
		
		/// <summary>
		/// The actual event you can add listeners to for when
		/// the timer starts ticking.
		/// </summary>
		public event tickEventHandler tick;
		
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Utils.Timer"/> class.
		/// </summary>
		/// <param name='milliseconds'>
		/// Milliseconds.
		/// </param>
		public Timer( float milliseconds )
		{
			//Converts milliseconds to seconds for easier
			//internal caluclations.
			_secondsToPass = (int)( milliseconds / 1000 );
			
			_ticking = false;
		}
				
		/// <summary>
		/// This method should be run in the game loop of a script
		/// that extends MonoBehavior. It's responsible for updating
		/// the timer so it can properly dispatch the events being
		/// listen for. Make note that it's running off of unity time.
		/// </summary>
		public void Update()
		{
			if( _started )
			{
				//If not ticking will set time to reach
				//
				if( _ticking == false )
				{	
					_timeToReach = Time.time + _secondsToPass;
					
					_ticking = true;
				}
				
				if( Math.Round( Time.time ) >= _timeToReach )
				{
					_ticking = false;
			
					tick( this, EventArgs.Empty );
				}
			}
		}
		
		 /// <summary>
		 /// This will start the timer and dispatch the 
		 /// tick event based on the amount of seconds passed
		 /// in the constructor.
		 /// </summary>
		public void Start() { _started = true; }
		
		/// <summary>
		/// This will reset the amount of time you need
		/// to reach before firing the next tick event.
		/// </summary>
		public void Reset() { _ticking = false; _timeToReach = 0; }
		
		/// <summary>
		/// This will only stop the current timer updating it will not reset it.
		/// Once the "Start()" method is called again it will pick up where it left off.
		/// </summary>
		public void Stop() { _started = false; }
	}
}