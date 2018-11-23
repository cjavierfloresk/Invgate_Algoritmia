using Invgate_Algoritmia.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Invgate_Algoritmia
{
	class Program
	{
		static void Main(string[] args)
		{
			//Process 4 tests files
			//We can get it from the args directly, but for the code challenge purposes I created a fixed list.
			var lstTests = new List<String>
			{
				"/Temp/test_case_1.txt",
				"/Temp/test_case_2.txt",
				"/Temp/test_case_3.txt"
			};

			foreach (var test in lstTests)
			{
				ProcessFile(test);
			}
		}

		private static void ProcessFile(string filepath)
		{
			Console.WriteLine(String.Format("Procesing file: {0}", filepath));
			try
			{
				//create the container of the file content
				//then we will work on it to create the TreeNote instances
				var content = new List<String>();

				//open the file
				FileStream fileStream = new FileStream(filepath, FileMode.Open);
				using (StreamReader reader = new StreamReader(fileStream))
				{
					string line = reader.ReadLine();
					while (line != null)
					{
						//add the line to the container
						content.Add(line);
						line = reader.ReadLine();
					}
				}

				//create the tree
				var tree = GetTreeNodes(content);

				//get the paths
				var parent = tree.First();
				var paths = GetTreePaths(parent, n => n.Children).ToList();

				//transform to empty format
				var lstOutput = new List<String>();
				foreach (var path in paths)
				{
					var tpath = path.ToList();
					tpath.Reverse();

					var output = string.Empty;

					foreach (var node in tpath)
					{
						output += node.Name + " ";
					}

					lstOutput.Add(output);
				}

				//sort the output
				lstOutput = lstOutput.OrderBy(x => x).ToList();

				//show the output
				Console.WriteLine("***** RESULTS ******");
				foreach (var o in lstOutput)
				{
					Console.WriteLine(o);
				}
				Console.WriteLine();
				Console.WriteLine("*******************************************************");	
				Console.WriteLine();

			}
			catch (IOException ioex)
			{
				//catch io exception
				Console.WriteLine(String.Format("IO ERROR: {0}", ioex.Message));
			}
			catch (Exception ex)
			{
				//catch general exception
				Console.WriteLine(String.Format("ERROR: {0}", ex.Message));
			}
			finally
			{
				//wait for a key press to make the console stay open, so we can read the log.
				Console.WriteLine("Press any key to close");
				Console.ReadKey();
			}
		}

		/// <summary>
		/// Go over the tree and get all the paths on it. Did it generic.
		/// </summary>
		/// <typeparam name="T">Node Class</typeparam>
		/// <param name="FirstItem">Root Node</param>
		/// <param name="Children">Children</param>
		/// <returns></returns>
		private static IEnumerable<IEnumerable<T>> GetTreePaths<T>(T firstNode, Func<T, IEnumerable<T>> children)
		{
			var child = children(firstNode);
			if (child != null && child.Any())
			{
				foreach (var ch in child)
					foreach (var ChildPath in GetTreePaths(ch, children))
						yield return new[] { firstNode }.Concat(ChildPath);
			}
			else
				yield return new[] { firstNode };
		}


		/// <summary>
		/// Create a list of tree nodes based on list of string
		/// </summary>
		/// <param name="content">List of string (text lines)</param>
		/// <returns>Tree</returns>
		private static List<TreeNode> GetTreeNodes(List<string> content)
		{
			var tree = new List<TreeNode>();

			//if content is null or empty, just return empty tree
			if (content == null || content.Count == 0) return tree;

			foreach (var line in content)
			{
				var arr = line.Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries);
				var parent = arr[0];
				var child = arr.Length == 2 ? arr[1] : "";

				AddTreeNode(tree, parent, child);
			}


			return tree;
		}

		/// <summary>
		/// Looks on the tree to add the node to the parent
		/// </summary>
		/// <param name="tree">Current tree</param>
		/// <param name="parent">Parent name</param>
		/// <param name="child">Child Name</param>
		/// <returns>Boolean</returns>
		private static bool AddTreeNode(List<TreeNode> tree, string parent, string child)
		{
			//if is the first, just add it
			if (tree.Count == 0)
			{
				var node = new TreeNode
				{
					Name = parent
				};

				if (!string.IsNullOrEmpty(child))
				{
					node.Children.Add(new TreeNode
					{
						Name = child
					});
				}

				tree.Add(node);
				return true;
			}
			else
			{
				foreach (var node in tree)
				{
					if (node.Name == parent)
					{
						node.Children.Add(new TreeNode
						{
							Name = child
						});
						return true;
					}
					else
					{
						if (AddTreeNode(node.Children, parent, child))
							return true;
					}
				}
			}

			return false;
		}
	}
}
