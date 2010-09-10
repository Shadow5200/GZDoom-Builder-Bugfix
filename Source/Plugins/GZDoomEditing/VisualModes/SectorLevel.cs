#region === Copyright (c) 2010 Pascal van der Heiden ===

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CodeImp.DoomBuilder.Geometry;
using CodeImp.DoomBuilder.Map;
using CodeImp.DoomBuilder.Rendering;

#endregion

namespace CodeImp.DoomBuilder.GZDoomEditing
{
	internal class SectorLevel : IComparable<SectorLevel>
	{
		// Center of sector to use for plane comparison
		public Vector2D center;
		
		// Type of level
		public SectorLevelType type;
		
		// Original sector
		public Sector sector;
		
		// Plane in the sector
		public Plane plane;
		
		// Alpha transparency
		public int alpha;
		
		// Color of the plane (includes brightness)
		// When this is 0, it takes the color from the sector above
		public int color;
		
		// Color and brightness below the plane
		// When this is 0, it takes the color from the sector above
		public int brightnessbelow;
		public PixelColor colorbelow;
		
		// Constructor
		public SectorLevel(Sector s, SectorLevelType type)
		{
			this.sector = s;
			this.type = type;
			this.center = new Vector2D(s.BBox.Left + s.BBox.Width / 2, s.BBox.Top + s.BBox.Height / 2);
			this.alpha = 255;
		}
		
		// Copy constructor
		public SectorLevel(SectorLevel source)
		{
			this.center = source.center;
			this.type = source.type;
			this.sector = source.sector;
			this.plane = source.plane;
			this.color = source.color;
			this.brightnessbelow = source.brightnessbelow;
			this.colorbelow = source.colorbelow;
			this.alpha = 255;
		}
		
		// Comparer
		public int CompareTo(SectorLevel other)
		{
			float delta = this.plane.GetZ(center) - other.plane.GetZ(center);
			
			if(delta > 0.0f)
				return 1;
			else if(delta < 0.0f)
				return -1;
			else
				return 0;
		}
	}
}