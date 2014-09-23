using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alpha.Core.ViewModels;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;

namespace Alpha.Droid.Fragments
{
	public class LoginDialogFragment : MvxDialogFragment
	{
		public override void OnCreate ( Bundle savedInstanceState )
		{
			base.OnCreate ( savedInstanceState );
		}

		public override Dialog OnCreateDialog(Bundle savedInstanceState)
		{
			base.EnsureBindingContextSet( savedInstanceState );

			var bindingInflater = this.BindingInflate(Resource.Layout.fragment_LoginDialog, null);

			var dlgBuilder = new AlertDialog
				.Builder ( Activity )
				.SetView ( bindingInflater )
				.SetTitle ( "Name Dialog" );

			return dlgBuilder.Create();
		}
	}
}

