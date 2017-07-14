using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using System;
using Android.Content;
using System.Collections.Generic;

namespace Transact
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
		//initalize database and account list
		public static Database db = new Database();
        public static List<Account> accounts = new List<Account>();
        public static ListView lstAccounts;
        public static AccountListViewAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource and attach an event to it
            lstAccounts = FindViewById<ListView>(Resource.Id.lstAccounts);
            Button addTransaction = FindViewById<Button>(Resource.Id.addTransaction);
            Button readButton = FindViewById<Button>(Resource.Id.btnReadRecords);
            Button btnAddAccount = FindViewById<Button>(Resource.Id.btnAddAccount);

            db = new Database();

            //load accounts from the database
            db.readAccounts();

            adapter = new AccountListViewAdapter(this, accounts);
            lstAccounts.Adapter = adapter;
            
            //click events for short and long of the listview for the accounts
            lstAccounts.ItemClick += LstAccounts_ItemClick;
            lstAccounts.ItemLongClick += LstAccounts_ItemLongClick;

            addTransaction.Click += delegate
            {
                var intent = new Intent(this, typeof(EnterTransaction));
                //intent.PutExtra("db_class", db);
                //intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };

            readButton.Click += async delegate { await db.readTransactionRecords(1); };

            btnAddAccount.Click += delegate {
                var intent = new Intent(this, typeof(AddAccount));
                //intent.PutExtra("db_class", db);
                //intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };
        }

        private void LstAccounts_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            makeToast(accounts[e.Position].Name + " was clicked!");
        }

        private void LstAccounts_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            makeToast(accounts[e.Position].Name + " was long clicked!");
        }

        public void makeToast(String message){
            Toast.MakeText(this, message, ToastLength.Short).Show();
        }
    }
}