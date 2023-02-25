using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EECore.Items
{
    public class Item
    {
        public string name         { get; }
        public string description  { get; }
        public Texture2D icon { get; protected set; }
        public Modifier modifier   { get; protected set; }

        public Item(
            string name, 
            string description) 
            : this(name, description, new Modifier()) { }

        public Item(
            string name, 
            string description, 
            Modifier modifier)
        {
            this.name = name;
            this.description = description;
            this.modifier = modifier;
        }
    }
}
