using System;
using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

public class Moves: MonoBehaviour {

	void Update() {

		if (gameObject.GetComponent<Figure>().moves) {
			
			if (gameObject.GetComponent<Figure>().choisefigure != null && gameObject.GetComponent<Figure>().choisefigure.name.Contains("pawn")) {
				
				String s = gameObject.GetComponent<Figure>().choisefigure.GetComponent<Trig>().triger.name;
				String first = s.Substring(0, 1);

				Debug.Log("////////////////////////////////////////////////");
				Debug.Log(first);
				int b = (int)(Convert.ToChar(first)-'0');

				// int b = Convert.ToChar(first) - '0';
				Debug.Log(b);
				// char c = (char)(b+'0');
				// Debug.Log(c);
				int intleftbukva = b - 1;
				int intrightbukva = b + 1;
				
				Debug.Log("////////////////////////////////////////////////");
				String stringsecond = s.Substring(1, 1);
				int intsecond = Int32.Parse(stringsecond);
				int intsecond1 = 0;
				int intsecond2 = 0;
				
				if (GameObject.Find("Camera").GetComponent<Xod>().StartIndex1 == true && gameObject.GetComponent<Figure>().choisefigure.name.Contains("white")) {
					
					intsecond1 = intsecond + 1;
					Debug.Log(intsecond1);
					intsecond2 = intsecond + 2;
					Debug.Log(intsecond2);
					
				}
				
				if (GameObject.Find("Camera").GetComponent<Xod>().StartIndex2 == true && gameObject.GetComponent<Figure>().choisefigure.name.Contains("black")) {
					
					intsecond1 = intsecond - 1;
					intsecond2 = intsecond - 2;
				}
				
				String final1=first+intsecond1.ToString();
				String final2=first+intsecond2.ToString();
				char charleftbukva = (char)(intleftbukva + '0');
				char charrightbukva = (char)(intrightbukva + '0');
                String finalchar1 = charleftbukva + intsecond1.ToString();
				String finalchar2 = charrightbukva + intsecond1.ToString();
                
				Debug.Log("////////////////////////////////////////////////");
				
				Debug.Log(finalchar1);
				Debug.Log(finalchar2);

				Debug.Log("////////////////////////////////////////////////");

				if(GameObject.Find(final1).GetComponent<Cell>().stoitfigura == false){    

                GameObject.Find(final1).GetComponent<Outline>().enabled = true;
				GameObject.Find(final1).GetComponent<Outline>().color = 1;
				GameObject.Find(final1).GetComponent<Cell>().cell = false;

					// if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex1 == false && GameObject.Find(final1).GetComponent<Cell>().figeureName.Contains("white")){

					// GameObject.Find(final1).GetComponent<Outline>().enabled = true;
					// GameObject.Find(final1).GetComponent<Outline>().color = 1;
					// }

					// if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex2 == false && GameObject.Find(final1).GetComponent<Cell>().figeureName.Contains("black")){

					// GameObject.Find(final1).GetComponent<Outline>().enabled = true;
					// GameObject.Find(final1).GetComponent<Outline>().color = 1;
					// }
				}

				if(GameObject.Find(final1).GetComponent<Cell>().stoitfigura == false && GameObject.Find(final2).GetComponent<Cell>().stoitfigura == false){

				GameObject.Find(final1).GetComponent<Outline>().enabled = true;
				GameObject.Find(final1).GetComponent<Outline>().color = 1;
				GameObject.Find(final1).GetComponent<Cell>().cell = false;
				GameObject.Find(final1).GetComponent<Cell>().cellvibranadlaxoda = true;

				GameObject.Find(final2).GetComponent<Outline>().enabled = true;
				GameObject.Find(final2).GetComponent<Outline>().color = 1;
				GameObject.Find(final2).GetComponent<Cell>().cell = false;
				GameObject.Find(final2).GetComponent<Cell>().cellvibranadlaxoda = true;
					// if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex1 == false && GameObject.Find(final1).GetComponent<Cell>().figeureName.Contains("white")){

					// GameObject.Find(final2).GetComponent<Outline>().enabled = true;
					// GameObject.Find(final2).GetComponent<Outline>().color = 1;
					// }

					// if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex2 == false && GameObject.Find(final1).GetComponent<Cell>().figeureName.Contains("black")){

					// GameObject.Find(final2).GetComponent<Outline>().enabled = true;
					// GameObject.Find(final2).GetComponent<Outline>().color = 1;
					// }
					
				}

                if(intleftbukva > 17){

                if(GameObject.Find(finalchar1).GetComponent<Cell>().stoitfigura == true){ 
					  Debug.Log("?????"); 
					if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex1 == false && GameObject.Find(finalchar1).GetComponent<Cell>().figeureName.Contains("white")){

					GameObject.Find(finalchar1).GetComponent<Outline>().enabled = true;
					GameObject.Find(finalchar1).GetComponent<Outline>().color = 0;
					GameObject.Find(finalchar1).GetComponent<Cell>().cellvibranadlaxoda = true;
					}

					if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex2 == false && GameObject.Find(finalchar1).GetComponent<Cell>().figeureName.Contains("black")){

					GameObject.Find(finalchar1).GetComponent<Outline>().enabled = true;
					GameObject.Find(finalchar1).GetComponent<Outline>().color = 0;
					GameObject.Find(finalchar1).GetComponent<Cell>().cellvibranadlaxoda = true;
					}
				}
				}

                if(intrightbukva < 25){
                if(GameObject.Find(finalchar2).GetComponent<Cell>().stoitfigura == true){  
					  Debug.Log("?????");   
					if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex1 == false && GameObject.Find(finalchar2).GetComponent<Cell>().figeureName.Contains("white")){

					GameObject.Find(finalchar2).GetComponent<Outline>().enabled = true;
					GameObject.Find(finalchar2).GetComponent<Outline>().color = 0;
					GameObject.Find(finalchar2).GetComponent<Cell>().cellvibranadlaxoda = true;
					}

					if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex2 == false && GameObject.Find(finalchar2).GetComponent<Cell>().figeureName.Contains("black")){

					GameObject.Find(finalchar2).GetComponent<Outline>().enabled = true;
					GameObject.Find(finalchar2).GetComponent<Outline>().color = 0;
					GameObject.Find(finalchar2).GetComponent<Cell>().cellvibranadlaxoda = true;
					}
				}
				}


				GameObject.Find(s).GetComponent<Outline>().enabled = true;
				GameObject.Find(s).GetComponent<Cell>().cell = false;
				GameObject.Find(s).GetComponent<Outline>().color = 1;
				// GameObject.Find(final1).GetComponent<Outline>().enabled = true;
				// GameObject.Find(final1).GetComponent<Outline>().color = 1;
				// GameObject.Find(final1).GetComponent<Cell>().cell = false;
				// GameObject.Find(final1).GetComponent<Cell>().cellvibranadlaxoda = true;
				// GameObject.Find(final2).GetComponent<Outline>().enabled = true;
				// GameObject.Find(final2).GetComponent<Outline>().color = 1;
				// GameObject.Find(final2).GetComponent<Cell>().cell = false;
				// GameObject.Find(final2).GetComponent<Cell>().cellvibranadlaxoda = true;


				gameObject.GetComponent<Figure>().camera.GetComponent<Moves>().enabled = false;
			    s = null;
				gameObject.GetComponent<Figure>().moves = false;
			}
			
			if (gameObject.GetComponent<Figure>().choisefigure.name.Contains("rook")) {
				
				String s = gameObject.GetComponent<Figure>().choisefigure.GetComponent<Trig>().triger.name;
				String first = s.Substring(0, 1);
				String stringsecond = s.Substring(1, 1);
				int intsecond = Int32.Parse(stringsecond);
				ArrayList cell = new ArrayList();
				
				foreach(String prefecs in gameObject.GetComponent<HiddenGO>().letters) {
					String g = prefecs + stringsecond;
					cell.Add(g);
				}
				
				foreach(String prefecs in gameObject.GetComponent<HiddenGO>().digit) {
					String g = first + prefecs;
					cell.Add(g);
				}
				
				foreach(String prefecs in cell) {
					GameObject.Find(prefecs).GetComponent<Outline>().enabled = true;
					GameObject.Find(prefecs).GetComponent<Cell>().cellvibranadlaxoda = true;
					GameObject.Find(prefecs).GetComponent<Cell>().cell = false;
				}
				
				gameObject.GetComponent<Figure>().camera.GetComponent<Moves>().enabled = false;
				gameObject.GetComponent<Figure>().moves = false;
			}
			
			if (gameObject.GetComponent<Figure>().choisefigure.name.Contains("knight")) {
				
				String s = gameObject.GetComponent<Figure>().choisefigure.GetComponent<Trig>().triger.name;
				String first = s.Substring(0, 1);
				String stringsecond = s.Substring(1, 1);
				int intsecond = Int32.Parse(stringsecond);
				int upint = intsecond + 2;
				int downint = intsecond - 2;
				int leftrightintup = intsecond + 1;
				int leftrightintdown = intsecond - 1;
				int b = Array.IndexOf(gameObject.GetComponent<HiddenGO>().letters, first);
				ArrayList cell = new ArrayList();
				
				if (b - 1 >= 0) {
					String upStringLeft = gameObject.GetComponent<HiddenGO>().letters[b - 1];
					
					if (intsecond + 2 <= 8) {
						
						String finalUpStringLeft = upStringLeft + upint.ToString();
						cell.Add(finalUpStringLeft);
					}
					
					if (intsecond - 2 >=1) {
						
						String finalDownStringLeft = upStringLeft+downint.ToString();
						cell.Add(finalDownStringLeft);
					}
				}
				
				if (b - 2 >= 0) {
					
					String stringLeft = gameObject.GetComponent<HiddenGO>().letters[b - 2];
					if (intsecond + 1 <= 8) {
						
						String finalStringLeftup = stringLeft+leftrightintup.ToString();
						cell.Add(finalStringLeftup);
					}
					if (intsecond - 1 >= 1) {
						
						String finalStringLeftdown = stringLeft+leftrightintdown.ToString();
						cell.Add(finalStringLeftdown);
					}
				}
				
				if (b + 1 <= 7) {
					
					String upStringRight = gameObject.GetComponent<HiddenGO>().letters[b+1];
					
					if (intsecond + 2 <= 8) {
						
						String finalUpStringRight = upStringRight+upint.ToString();
						cell.Add(finalUpStringRight);
					}
					
					if (intsecond - 2 >= 1) {
						
						String finalDownStringRight = upStringRight+downint.ToString();
						cell.Add(finalDownStringRight);
					}
				}
				
				if (b + 2 <= 7) {
					String stringRight = gameObject.GetComponent<HiddenGO>().letters[b + 2];
					
					if (intsecond + 1 <= 8) {
						
						String finalStringRightup = stringRight+leftrightintup.ToString();
						cell.Add(finalStringRightup);
					}
					
					if (intsecond - 1 >= 1) {
						
						String finalStringRightdown = stringRight+leftrightintdown.ToString();
						cell.Add(finalStringRightdown);
					}
				}
				
				foreach(String prefecs in cell) {
					
					if (prefecs != null) {
						GameObject.Find(prefecs).GetComponent<Outline>().enabled = true;
						GameObject.Find(prefecs).GetComponent<Cell>().cell = false;
			        	GameObject.Find(prefecs).GetComponent<Cell>().cellvibranadlaxoda = true;
					}
				}
				
				gameObject.GetComponent<Figure>().camera.GetComponent<Moves>().enabled = false;
				gameObject.GetComponent<Figure>().moves = false;
			}
			
			if (gameObject.GetComponent<Figure>().choisefigure.name.Contains("bishop")) {
				
				String s = gameObject.GetComponent<Figure>().choisefigure.GetComponent<Trig>().triger.name;
				String first = s.Substring(0, 1);
				String stringsecond = s.Substring(1, 1);
				int a = Int32.Parse(stringsecond);
				int b = Array.IndexOf(gameObject.GetComponent<HiddenGO>().letters, first);
				ArrayList cell = new ArrayList();
				
				for (int i=1; i < 8; i++) {
					
					int c = b + i;
					
					if (c <= 7) {
						
						String e = gameObject.GetComponent<HiddenGO>().letters[c];
						int r = a + i;
						
						if (r <= 7) {
							
							String upright = e + r.ToString();
							cell.Add(upright);
						}
						
						int t=a - i;
						
						if (t >=1) {
							
							String downright=e+t.ToString();
							cell.Add(downright);
						}
						
						else continue;
						
						int g = b - i;
						
						if (g >= 0) {
							
							String h = gameObject.GetComponent<HiddenGO>().letters[g];
							int u = a + i;
							if (u <= 7) {
								
								String upleft = h + u.ToString();
								cell.Add(upleft);
							}
							
							int m = a - i;
							if (m >= 1) {
								
								String downleft= h + m.ToString();
								cell.Add(downleft);
							}
							
							else continue;
						}
					}
				}
				
				foreach(String prefecs in cell) {
					
					GameObject.Find(prefecs).GetComponent<Outline>().enabled = true;
					GameObject.Find(prefecs).GetComponent < Cell>().cellvibranadlaxoda = true;
					GameObject.Find(prefecs).GetComponent < Cell>().cell = false;
				}
				
				gameObject.GetComponent<Figure>().camera.GetComponent<Moves>().enabled = false;
				gameObject.GetComponent<Figure>().moves = false;
			}
			
			if (gameObject.GetComponent<Figure>().choisefigure.name.Contains("queen")) {
				
				String s = gameObject.GetComponent<Figure>().choisefigure.GetComponent<Trig>().triger.name;
				String first = s.Substring(0, 1);
				String stringsecond = s.Substring(1, 1);
				int intsecond = Int32.Parse(stringsecond);
				ArrayList cell = new ArrayList();
				
				foreach(String prefecs in gameObject.GetComponent<HiddenGO>().letters) {
					
					String g = prefecs + stringsecond;
					cell.Add(g);
				}
				
				foreach(String prefecs in gameObject.GetComponent<HiddenGO>().digit) {
					String g = first + prefecs;
					cell.Add(g);
				}
				
				int a = Int32.Parse(stringsecond);
				int b = Array.IndexOf(gameObject.GetComponent<HiddenGO>().letters, first);
				
				for (int i = 1; i < 8; i++) {
					
					int c = b + i;
					
					if (c <= 7) {
						
						String e = gameObject.GetComponent<HiddenGO>().letters[c];
						int r = a + i;
						
						if (r <= 7) {
							
							String upright = e + r.ToString();
							cell.Add(upright);
						}
						
						int t = a - i;

						if (t >= 1) {
							
							String downright = e + t.ToString();
							cell.Add(downright);
						}
						
						else continue;
					}
					
					int g = b - i;
					
					if (g >= 0) {
						
						String h = gameObject.GetComponent<HiddenGO>().letters[g];
						int u = a + i;
						if (u <= 7) {
							
							String upleft = h + u.ToString();
							cell.Add(upleft);
						}
						
						int m = a - i;
						
						if (m >= 1) {
							
							String downleft = h + m.ToString();
							cell.Add(downleft);
						}
						
						else continue;
					}
					
					foreach(String prefecs in cell) {
						
						GameObject.Find(prefecs).GetComponent<Outline>().enabled = true;
						GameObject.Find(prefecs).GetComponent<Cell>().cellvibranadlaxoda = true;
						GameObject.Find(prefecs).GetComponent<Cell>().cell = false;
					}
					
					gameObject.GetComponent<Figure>().camera.GetComponent<Moves>().enabled = false;
					gameObject.GetComponent<Figure>().moves = false;
				}
			}
		}
		
		if (gameObject.GetComponent<Figure>().choisefigure.name.Contains("king")) {
			
			String s = gameObject.GetComponent<Figure>().choisefigure.GetComponent<Trig>().triger.name;
			String first = s.Substring(0, 1);
			String stringsecond = s.Substring(1, 1);
			int intsecond = Int32.Parse(stringsecond);
			int b = Array.IndexOf(gameObject.GetComponent<HiddenGO>().letters, first);
			ArrayList cell = new ArrayList();
			int upint = intsecond + 1;
			int downint = intsecond - 1;

			if (intsecond + 1 <= 8) {
				
				String finalUp = first + upint.ToString();
				cell.Add(finalUp);
			}
			
			if (intsecond - 1 >= 1) {
				
				String finalDown = first + downint.ToString();
				cell.Add(finalDown);
			}
			
			if (b - 1 >= 0) {

				String upStringLeft = gameObject.GetComponent<HiddenGO>().letters[b - 1];
				
				if (intsecond + 1 <= 8) {
					
					String finalUpStringLeft = upStringLeft + upint.ToString();
					String finalLeft = upStringLeft + intsecond.ToString();
					cell.Add(finalUpStringLeft);
					cell.Add(finalLeft);
				}
				
				if (intsecond - 1 >= 1) {
					
					String finalDownStringLeft = upStringLeft + downint.ToString();
					cell.Add(finalDownStringLeft);
				}
			}
			
			if (b + 1 <= 7) {
				
				String upStringRight = gameObject.GetComponent<HiddenGO>().letters[b + 1];
				
				if (intsecond + 1 <= 8) {
					
					String finalUpStringRight = upStringRight + upint.ToString();
					String finalRight = upStringRight + intsecond.ToString();
					cell.Add(finalRight);
					cell.Add(finalUpStringRight);
				}
				
				if (intsecond - 1 >= 1) {
					
					String finalDownStringRight = upStringRight + downint.ToString();
					cell.Add(finalDownStringRight);
				}
			}
			
			foreach(String prefecs in cell) {
				
				if (prefecs != null) {
					
					GameObject.Find(prefecs).GetComponent<Outline>().enabled = true;
					GameObject.Find(prefecs).GetComponent<Cell>().cellvibranadlaxoda = true;
					GameObject.Find(prefecs).GetComponent<Cell>().cell = false;
				}
			}
			
			gameObject.GetComponent<Figure>().camera.GetComponent<Moves>().enabled = false;
			gameObject.GetComponent<Figure>().moves = false;
		}
	}
}