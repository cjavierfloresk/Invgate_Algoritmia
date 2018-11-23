using System;
using System.Collections.Generic;
using System.Text;

namespace Invgate_Algoritmia.Entities
{
	public class TreeNode
	{
		public TreeNode()
		{
			//just to avoid null exceptions
			Children = new List<TreeNode>();
		}

		public string Name { get; set; }

		public List<TreeNode> Children { get; set;}
	}
}
