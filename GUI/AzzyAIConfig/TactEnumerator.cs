// TactEnumerator.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains the TactEnumerator, which implements the generic
// interface IEnumerator<T>.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;


namespace AzzyAIConfig
{
    class TactEnumerator : System.Collections.Generic.IEnumerator<Tact>
    {
        Tact[] _list;
        int _index = -1;

        public TactEnumerator(Tact[] list)
        {
            // Set the list array
            _list = list;
        }

        public Tact Current
        {
            get { return _list[_index]; }
        }

        public void Dispose()
        {
        }

        object IEnumerator.Current
        {
            get { return _list[_index]; }
        }

        public bool MoveNext()
        {
            // Increment the index
            _index++;

            // Check if the index is within the list bounds
            if (_index < _list.Length)
            {
                // Return true
                return true;
            }

            // Return false
            return false;
        }

        public void Reset()
        {
            // Reset the index
            _index = -1;
        }
    }
}