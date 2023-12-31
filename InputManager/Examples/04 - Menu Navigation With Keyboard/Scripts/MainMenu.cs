using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace TeamUtility.IO.Examples
{
	public class MainMenu : MonoBehaviour 
	{
		[SerializeField]
		private MenuPage m_startPage;

		[SerializeField]
		private MenuPage[] m_pages;

		private MenuPage m_currentPage;

		private void Start()
		{
			ChangePage(m_startPage.ID);
		}

		public void ChangePage(string id)
		{
			if(m_currentPage != null)
				m_currentPage.gameObject.SetActive(false);

			m_currentPage = FindPage(id);
			if(m_currentPage != null)
			{
				m_currentPage.gameObject.SetActive(true);
				EventSystem.current.SetSelectedGameObject(m_currentPage.FirstSelected);
			}
		}

		private MenuPage FindPage(string id)
		{
			foreach(MenuPage page in m_pages)
			{
				if(page.ID == id)
					return page;
			}

			Debug.LogError("Unable to find menu page with id: " + id);
			return null;
		}
	}
}
