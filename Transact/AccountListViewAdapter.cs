using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Transact
{
    public class AccountListViewAdapter : BaseAdapter<Account>
    {
        private List<Account> mItems;
        private Context mContext;

        public AccountListViewAdapter(Context context, List<Account> items)
        {
            mItems = items;
            mContext = context;
        }

        public override int Count => mItems.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Account this[int position] => mItems[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if(row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listView_accounts, null, false);
            }

            TextView txtAccountName = row.FindViewById<TextView>(Resource.Id.txtAccountName);
            txtAccountName.Text = mItems[position].Name;

            TextView txtAccountNote = row.FindViewById<TextView>(Resource.Id.txtAccountNote);
            txtAccountNote.Text = mItems[position].Note;

            TextView txtAccountTotal = row.FindViewById<TextView>(Resource.Id.txtAccountBalance);
            txtAccountTotal.Text = "$" + mItems[position].Balance;

            return row;
        }
    }
}