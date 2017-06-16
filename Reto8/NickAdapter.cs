using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace reto8
{
    public class NickAdapter : BaseAdapter<Nick>
    {
        Activity activity;
        int layoutResourceId;
        List<Nick> items = new List<Nick>();

        public NickAdapter(Activity activity, int layoutResourceId)
        {
            this.activity = activity;
            this.layoutResourceId = layoutResourceId;
        }

        //Returns the view for a specific item on the list
        public override View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {
            var row = convertView;
            var currentItem = this[position];
            CheckBox checkBox;

            if (row == null)
            {
                var inflater = activity.LayoutInflater;
                row = inflater.Inflate(layoutResourceId, parent, false);

                checkBox = row.FindViewById<CheckBox>(Resource.Id.checkNick);

                checkBox.CheckedChange += async (sender, e) => {
                    var cbSender = sender as CheckBox;
                    if (cbSender != null && cbSender.Tag is NickWrapper && cbSender.Checked)
                    {
                        cbSender.Enabled = false;
                        if (activity is NickActivity)
                            await ((NickActivity)activity).CheckItem((cbSender.Tag as NickWrapper).Nick);
                    }
                };
            }
            else
                checkBox = row.FindViewById<CheckBox>(Resource.Id.checkNick);

            checkBox.Text = currentItem.description;
            checkBox.Checked = false;
            checkBox.Enabled = true;
            checkBox.Tag = new NickWrapper(currentItem);

            return row;
        }

        public void Add(Nick item)
        {
            items.Add(item);
            NotifyDataSetChanged();
        }

        public void Clear()
        {
            items.Clear();
            NotifyDataSetChanged();
        }

        public void Remove(Nick item)
        {
            items.Remove(item);
            NotifyDataSetChanged();
        }

        #region implemented abstract members of BaseAdapter

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override Nick this[int position]
        {
            get
            {
                return items[position];
            }
        }

        #endregion
    }
}

