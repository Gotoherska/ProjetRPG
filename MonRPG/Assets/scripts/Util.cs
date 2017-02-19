using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace util
{
	public class MultList<T>
	{
		List<MultList<T>> subList;
		List<T> list;
		private int depth;

		private MultList(){
		}
		public MultList(int n)
		{
			depth = n;
			if (n < 1) {
				list = new List<T>();
			} else {
				subList = new List<MultList<T>>(n-1);
			}
		}

		public void insert(ArrayList n, T t)
		{
		}
	}
}