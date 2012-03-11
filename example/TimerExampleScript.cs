using UnityEngine;
using System.Collections;
using System;
using Utils;

//This is a simple example of how to use the timer
//class I wrote, it uses the tickCounter to keep
//track of the count down which is trigger
//every time the tick event is fired. which 
//happens every 1000 milliseconds.
public class TimerExampleScript : MonoBehaviour
{
	public Timer timer;
	
	public int tickCounter;
	
	
	public void Start() 
	{
		timer = new Timer( 1000 );
	 
		timer.tick += onTick;
		timer.Start();
		
		tickCounter = 60;
		
		guiText.text = tickCounter + " Seconds Left";
	}	
	
	public void onTick(  System.Object o, System.EventArgs e )
	{
		if( tickCounter != 0 )
		{
			tickCounter--;
			guiText.text = tickCounter + " Seconds Left";
		}
		else
		{
			guiText.text = "Yay it's over!";
			timer.Stop();	
		}
	}	
	
	public void Update() 
	{
		timer.Update();
	}
}
