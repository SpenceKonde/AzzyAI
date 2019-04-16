// TactCollection.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains code for the TactCollection class, which implements
// the generic interface ICollection<T>.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;


namespace AzzyAIConfig
{
    class TactCollection : System.Collections.Generic.ICollection<Tact>
    {
        Tact[] _items = new Tact[0];

        public TactCollection()
        {
        }

        public TactCollection(Tact[] items)
        {
            // Set the items array
            _items = items;
        }

        public TactCollection(Tact[] items, bool readOnly)
        {
            // Set the items array
            _items = items;

            // Set the collection as read only
            _readOnly = readOnly;
        }

        public void Add(Tact item)
        {
            // Check if the collection is read only
            if (_readOnly)
            {
                // Throw a new exception
                throw new Exception("The collection is read-only.");
            }
            // If the collection is not read only
            else
            {
                // Create a new tactics array
                Tact[] old = new Tact[_items.Length];

                // Copy the old tactics array to the new one
                _items.CopyTo(old, 0);

                // Create a new tactics array with one more slot than the old one
                _items = new Tact[old.Length + 1];

                // Copy the old tactics array to the new one
                old.CopyTo(_items, 0);

                // Set the last slot of the new array to the new tactic
                _items[old.Length] = item;

                // Sort the array
                Array.Sort(_items);
            }
        }

        public void Clear()
        {
            // Check if the collection is read only
            if (_readOnly)
            {
                // Throw a new exception
                throw new Exception("The collection is read-only.");
            }
            // If the collection is not read only
            else
            {
                // Clear the collection array
                _items = new Tact[0];
            }
        }

        public bool Contains(Tact item)
        {
            // Check if the collection array has more than one item
            if (_items.Length > 0)
            {
                // Create a new tactics array
                Tact[] search = new Tact[_items.Length];

                // Copy the old tactics array to the new one
                _items.CopyTo(search, 0);

                // Run through the tactics in the new array
                foreach (Tact t in search)
                {
                    // Check if the current tactic equals item
                    if (t == item)
                    {
                        // Return true
                        return true;
                    }
                }
            }

            // Return false
            return false;
        }

        public void CopyTo(Tact[] array, int arrayIndex)
        {
            // Cope the collection array to array at arrayIndex
            _items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _items.Length; }
        }

        bool _readOnly = false;
        public bool IsReadOnly
        {
            get { return _readOnly; }
        }

        public bool Remove(Tact item)
        {
            // Check if the collection is read only
            if (_readOnly)
            {
                // Throw a new exception
                throw new Exception("The collection is read-only.");
            }
            // If the collection is not read only and contains item
            else if (Contains(item))
            {
                // Create a new tactics array
                Tact[] old = new Tact[_items.Length];

                // Copy the old tactics array to the new one
                _items.CopyTo(old, 0);

                // Replace the item with the last tactic in the array
                int i = 0;
                while (old[i] != item) i++;
                if (old[i] == item)
                {
                    old[i] = old[old.Length - 1];
                }

                // Create a new tactics array with one less slot than the old one
                _items = new Tact[old.Length - 1];

                // Run through all the slots in the new array
                for (i = 0; i < _items.Length; i++)
                {
                    // Create a new tactic from the old one in the old array
                    _items[i] = new Tact(old[i].ID, old[i].Name, old[i].TACT_BASIC, old[i].TACT_SKILL, old[i].TACT_KITE, old[i].TACT_CAST, old[i].TACT_PUSHBACK, old[i].TACT_DEBUFF, old[i].TACT_SKILLCLASS, old[i].TACT_RESCUE, old[i].TACT_SP,old[i].TACT_SNIPE, old[i].TACT_KS, old[i].TACT_WEIGHT, old[i].TACT_CHASE);
                }

                // Sort the new array
                Array.Sort(_items);

                // Return true
                return true;
            }

            // Return false
            return false;
        }

        public IEnumerator<Tact> GetEnumerator()
        {
            // Return the enumerator for this collection
            return new TactEnumerator(_items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}