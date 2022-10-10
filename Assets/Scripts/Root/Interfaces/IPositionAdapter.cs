using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Outworld.Main.Interfaces
{
    public interface IPositionAdapter
    {
        public Vector2 LocalPosition { get; set; }
        public Vector2 GlobalPosition { get; set; }
    }
}
