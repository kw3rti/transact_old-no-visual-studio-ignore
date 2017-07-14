using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace Transact
{
    [Activity(Label = "@string/enter_activity")]
    public class EnterTransaction : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.EnterTransaction);

			//Intent passedIntent = getIntent();
			//Database db = (Database)passedIntent.getSerializableExtra("db_class");

            // Get our button from the layout resource and attach an event to it
            Button insertButton = FindViewById<Button>(Resource.Id.btnAddTransaction);
            Button cancelButton = FindViewById<Button>(Resource.Id.btnCancelTransaction);

            EditText title = FindViewById<EditText>(Resource.Id.txtTitle);
            EditText amount = FindViewById<EditText>(Resource.Id.txtAmount);
            EditText date = FindViewById<EditText>(Resource.Id.txtDate);
            EditText category = FindViewById<EditText>(Resource.Id.txtCategory);
            EditText type_toaccount = FindViewById<EditText>(Resource.Id.txtType_ToAccount);
            EditText notes = FindViewById<EditText>(Resource.Id.txtNotes);

            insertButton.Click += delegate {
                enterTransaction(1, date, title, amount, category, type_toaccount, notes);
                this.Finish();
            };
            cancelButton.Click += delegate { this.Finish(); };
        }

        private async void enterTransaction(int accountPK, EditText date, EditText title, EditText amount, EditText category, EditText type_toaccount, EditText notes){
            //do checks to make sure data is entered into form before saving
            if(title.Text != ""){
                if (amount.Text != ""){
                    if (date.Text != ""){
                        if(category.Text != ""){
                            if(type_toaccount.Text != ""){
                                await MainActivity.db.addTransaction(accountPK, Convert.ToDateTime(date.Text.ToString()), title.Text, Convert.ToDecimal(amount.Text), category.Text, type_toaccount.Text, notes.Text);                   
                            }
                            else{
                                type_toaccount.RequestFocus();
								Toast.MakeText(this, "Type cannot be null/empty", ToastLength.Short).Show();
                            }
                        }
                        else{
							category.RequestFocus();
							Toast.MakeText(this, "Category cannot be null/empty", ToastLength.Short).Show();
                        }
                    }
                    else{
						date.RequestFocus();
						Toast.MakeText(this, "Date cannot be null/empty", ToastLength.Short).Show();
                    }
                }
                else{
					amount.RequestFocus();
					Toast.MakeText(this, "Amount cannot be null/empty", ToastLength.Short).Show();
                }  
            }
            else{
                title.RequestFocus();
                Toast.MakeText(this, "Item cannot be null/empty", ToastLength.Short).Show();
            }
           
        }
    }
}