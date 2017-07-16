using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Transact
{
    [Activity(Label = "@string/enter_activity")]
    public class Transactions : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Transactions);

            var accountPK = Intent.GetIntExtra("AccountPK",0);

            // Get our button from the layout resource and attach an event to it
            Button addTransaction = FindViewById<Button>(Resource.Id.btnAddTransaction1);


            addTransaction.Click += delegate {
				var intent = new Intent(this, typeof(EnterTransaction));
				intent.PutExtra("AccountPK", accountPK);
				StartActivity(intent);
            };
        }
    }
}