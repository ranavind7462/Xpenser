using System;
using System.Collections.Generic;
using System.Text;

namespace Xpenser.UI
{
   public class appState
    {
        private long _accountId;
        public long AccountId
        {
            get
            {
                return _accountId;
            }
            set
            {
                _accountId = value;
                NotifyDataChanged();
            }
        }
        public event Action OnChange;

        private void NotifyDataChanged() => OnChange?.Invoke();
    }
}
