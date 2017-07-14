using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace Transact
{
    [Activity(Label = "@string/add_account")]
    public class AddAccount : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.AddAccount);

            // Get our button from the layout resource and attach an event to it
            Button addButton = FindViewById<Button>(Resource.Id.btnAccountAdd);
            Button cancelButton = FindViewById<Button>(Resource.Id.btnAccountCancel);

            EditText name = FindViewById<EditText>(Resource.Id.txtAccountName);
            EditText note = FindViewById<EditText>(Resource.Id.txtAccountNote);
            EditText startBalance = FindViewById<EditText>(Resource.Id.txtAccountStartBalance);
            EditText type = FindViewById<EditText>(Resource.Id.txtAccountType);
          
            addButton.Click += async delegate {
                await MainActivity.db.addAccount(name.Text, note.Text, type.Text, Convert.ToDecimal(startBalance.Text), DateTime.Now, "Initial Balance", "", "");
                MainActivity.lstAccounts.Adapter = MainActivity.adapter;
                this.Finish();
            };
            cancelButton.Click += delegate { this.Finish(); };
        }
    }
}