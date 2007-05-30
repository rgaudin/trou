//
// trou, a replacement tool for pbcopy
// (C) 2007 Gaudin & Evain
//


using System;
using System.Threading;

using Gtk;

class Program {

	static TargetEntry[] targets= new TargetEntry[]{ new TargetEntry("UTF8_STRING", 0, 0)};
	
	static bool read_done = false;

	public static void Main(string[] args)
	{
	
		Application.Init ();
		Thread t = new Thread (ExitIfDone);
		t.Start ();
		
		CopyPasteTest ();
	
		Application.Run ();
	}

	static void CopyPasteTest ()
	{
		
		Clipboard clipboard = Clipboard.Get(Gdk.Atom.Intern("CLIPBOARD", true));

		clipboard.SetWithData(targets, new ClipboardGetFunc(OnClipboardGet), new ClipboardClearFunc(OnClipboardClear));
	}
	
	static void ExitIfDone ()
	{
		while (!read_done) {
			Thread.Sleep (50);
		}
		Application.Quit ();
	}


	static void OnClipboardGet(Clipboard cb, SelectionData sd, uint i)
	{
		sd.Text = Console.In.ReadToEnd ();
		read_done = true;
	} 

	static void OnClipboardClear(Clipboard cb)
	{
	}

}