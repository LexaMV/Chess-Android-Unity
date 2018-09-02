using System;
using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

public class Moves : MonoBehaviour {

	void Update () {

		if (gameObject.GetComponent<Figure> ().moves) {

# region Pawn
			if (gameObject.GetComponent<Figure> ().choisefigure != null && gameObject.GetComponent<Figure> ().choisefigure.name.Contains ("pawn")) {

				String s = gameObject.GetComponent<Figure> ().choisefigure.GetComponent<Trig> ().triger.name;
				String first = s.Substring (0, 1);
				int b = (int) (Convert.ToChar (first) - '0');
				int intleftbukva = b - 1;
				int intrightbukva = b + 1;
				String stringsecond = s.Substring (1, 1);
				int intsecond = Int32.Parse (stringsecond);
				int intsecond1 = 0;
				int intsecond2 = 0;

				if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == true && gameObject.GetComponent<Figure> ().choisefigure.name.Contains ("white")) {

					intsecond1 = intsecond + 1;
					Debug.Log (intsecond1);
					intsecond2 = intsecond + 2;
					Debug.Log (intsecond2);
				}

				if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 == true && gameObject.GetComponent<Figure> ().choisefigure.name.Contains ("black")) {

					intsecond1 = intsecond - 1;
					intsecond2 = intsecond - 2;
				}

				String final1 = first + intsecond1.ToString ();
				String final2 = first + intsecond2.ToString ();
				char charleftbukva = (char) (intleftbukva + '0');
				char charrightbukva = (char) (intrightbukva + '0');
				String finalchar1 = charleftbukva + intsecond1.ToString ();
				String finalchar2 = charrightbukva + intsecond1.ToString ();

				if (GameObject.Find (final1).GetComponent<Cell> ().stoitfigura == false) {

					GameObject.Find (final1).GetComponent<Outline> ().enabled = true;
					GameObject.Find (final1).GetComponent<Outline> ().color = 1;
					GameObject.Find (final1).GetComponent<Cell> ().cell = false;
				}

				if (GameObject.Find (final1).GetComponent<Cell> ().stoitfigura == false && GameObject.Find (final2).GetComponent<Cell> ().stoitfigura == false) {

					GameObject.Find (final1).GetComponent<Outline> ().enabled = true;
					GameObject.Find (final1).GetComponent<Outline> ().color = 1;
					GameObject.Find (final1).GetComponent<Cell> ().cell = false;
					GameObject.Find (final1).GetComponent<Cell> ().cellvibranadlaxoda = true;

					GameObject.Find (final2).GetComponent<Outline> ().enabled = true;
					GameObject.Find (final2).GetComponent<Outline> ().color = 1;
					GameObject.Find (final2).GetComponent<Cell> ().cell = false;
					GameObject.Find (final2).GetComponent<Cell> ().cellvibranadlaxoda = true;
				}

				if (intleftbukva > 17) {

					if (GameObject.Find (finalchar1).GetComponent<Cell> ().stoitfigura == true) {

						if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == false && GameObject.Find (finalchar1).GetComponent<Cell> ().figeureName.Contains ("white")) {

							GameObject.Find (finalchar1).GetComponent<Outline> ().enabled = true;
							GameObject.Find (finalchar1).GetComponent<Outline> ().color = 0;
							GameObject.Find (finalchar1).GetComponent<Cell> ().cell = false;
							GameObject.Find (finalchar1).GetComponent<Cell> ().cellvibranadlaxoda = true;
						}

						if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 == false && GameObject.Find (finalchar1).GetComponent<Cell> ().figeureName.Contains ("black")) {

							GameObject.Find (finalchar1).GetComponent<Outline> ().enabled = true;
							GameObject.Find (finalchar1).GetComponent<Outline> ().color = 0;
							GameObject.Find (finalchar1).GetComponent<Cell> ().cell = false;
							GameObject.Find (finalchar1).GetComponent<Cell> ().cellvibranadlaxoda = true;
						}
					}
				}

				if (intrightbukva < 25) {
					if (GameObject.Find (finalchar2).GetComponent<Cell> ().stoitfigura == true) {

						if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == false && GameObject.Find (finalchar2).GetComponent<Cell> ().figeureName.Contains ("white")) {

							GameObject.Find (finalchar2).GetComponent<Outline> ().enabled = true;
							GameObject.Find (finalchar2).GetComponent<Outline> ().color = 0;
							GameObject.Find (finalchar2).GetComponent<Cell> ().cell = false;
							GameObject.Find (finalchar2).GetComponent<Cell> ().cellvibranadlaxoda = true;
						}

						if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 == false && GameObject.Find (finalchar2).GetComponent<Cell> ().figeureName.Contains ("black")) {

							GameObject.Find (finalchar2).GetComponent<Outline> ().enabled = true;
							GameObject.Find (finalchar2).GetComponent<Outline> ().color = 0;
							GameObject.Find (finalchar2).GetComponent<Cell> ().cell = false;
							GameObject.Find (finalchar2).GetComponent<Cell> ().cellvibranadlaxoda = true;
						}
					}
				}

				GameObject.Find (s).GetComponent<Outline> ().enabled = true;
				GameObject.Find (s).GetComponent<Cell> ().cell = false;
				GameObject.Find (s).GetComponent<Outline> ().color = 1;
				gameObject.GetComponent<Figure> ().camera.GetComponent<Moves> ().enabled = false;
				s = null;
				gameObject.GetComponent<Figure> ().moves = false;
			}

#endregion

#region Rook
			if (gameObject.GetComponent<Figure> ().choisefigure.name.Contains ("rook")) {

				String s = gameObject.GetComponent<Figure> ().choisefigure.GetComponent<Trig> ().triger.name;
				String first = s.Substring (0, 1);
				int b = (int) (Convert.ToChar (first) - '0');
				String stringsecond = s.Substring (1, 1);
				int intsecond = Int32.Parse (stringsecond);
				bool left = true;
				bool right = true;
				bool konecCiklaCelldigitIntPlus = true;
				bool konecCiklaCelldigitIntMinus = true;
				ArrayList cell = new ArrayList ();

				for (int v = 1; v < 8; v++) {

					if (right) {
						int a = b + v;
						char u = (char) (a + '0');
						String e = u.ToString ();
						String l = e + intsecond;
						Debug.Log ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
						Debug.Log (l);
						if (a < 17 || a > 24) {
							right = false;
							break;
						}
						cell.Add (l);
					}
				}

				PereborMassiva (cell);
				cell.Clear ();

				for (int k = 1; k < 8; k++) {

					if (left) {
						int o = b - k;
						char x = (char) (o + '0');
						String n = x.ToString ();
						String z = n + intsecond;
						Debug.Log ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
						Debug.Log (z);
						if (o < 17 || o > 24) {
							left = false;
							break;
						}
						cell.Add (z);

					}
				}

				PereborMassiva (cell);
				cell.Clear ();

				for (int i = 1; i < 8; i++) {
					if (konecCiklaCelldigitIntPlus) {
						int a = intsecond + i;
						String e = a.ToString ();
						String l = first + e;
						Debug.Log ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
						Debug.Log (l);
						if (l.Contains ("9")) {
							konecCiklaCelldigitIntPlus = false;
							break;
						}
						cell.Add (l);
					}
				}

				PereborMassiva (cell);
				cell.Clear ();

				for (int m = 1; m < 8; m++) {
					if (konecCiklaCelldigitIntMinus) {
						int a = intsecond - m;
						String e = a.ToString ();
						String l = first + e;
						Debug.Log ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
						Debug.Log (l);
						if (l.Contains ("0")) {
							konecCiklaCelldigitIntPlus = false;
							break;
						}
						cell.Add (l);
					}
				}

				PereborMassiva (cell);
				cell.Clear ();

				gameObject.GetComponent<Figure> ().camera.GetComponent<Moves> ().enabled = false;
				gameObject.GetComponent<Figure> ().moves = false;
			}

#endregion
		
		#region  Knight
			if (gameObject.GetComponent<Figure> ().choisefigure.name.Contains ("horse")) {
				

				String s = gameObject.GetComponent<Figure> ().choisefigure.GetComponent<Trig> ().triger.name;
				String first = s.Substring (0, 1);
				String stringsecond = s.Substring (1, 1);
				int intsecond = Int32.Parse (stringsecond);
				int upint = intsecond + 2;
				int downint = intsecond - 2;
				int leftrightintup = intsecond + 1;
				int leftrightintdown = intsecond - 1;
				int b = Array.IndexOf (gameObject.GetComponent<HiddenGO> ().letters, first);
				ArrayList cell = new ArrayList ();

				if (b - 1 >= 0) {
					String upStringLeft = gameObject.GetComponent<HiddenGO> ().letters[b - 1];

					if (intsecond + 2 <= 8) {

						String finalUpStringLeft = upStringLeft + upint.ToString ();
						cell.Add (finalUpStringLeft);
					}

					if (intsecond - 2 >= 1) {

						String finalDownStringLeft = upStringLeft + downint.ToString ();
						cell.Add (finalDownStringLeft);
					}
				}

				// if (b - 2 >= 0) {

				// 	String stringLeft = gameObject.GetComponent<HiddenGO> ().letters[b - 2];
				// 	if (intsecond + 1 <= 8) {

				// 		String finalStringLeftup = stringLeft + leftrightintup.ToString ();
				// 		cell.Add (finalStringLeftup);
				// 	}
				// 	if (intsecond - 1 >= 1) {

				// 		String finalStringLeftdown = stringLeft + leftrightintdown.ToString ();
				// 		cell.Add (finalStringLeftdown);
				// 	}
				// }

				if (b + 1 <= 7) {

					String upStringRight = gameObject.GetComponent<HiddenGO> ().letters[b + 1];

					if (intsecond + 2 <= 8) {

						String finalUpStringRight = upStringRight + upint.ToString ();
						cell.Add (finalUpStringRight);
					}

					if (intsecond - 2 >= 1) {

						String finalDownStringRight = upStringRight + downint.ToString ();
						cell.Add (finalDownStringRight);
					}
				}

				// if (b + 2 <= 7) {
				// 	String stringRight = gameObject.GetComponent<HiddenGO> ().letters[b + 2];

				// 	if (intsecond + 1 <= 8) {

				// 		String finalStringRightup = stringRight + leftrightintup.ToString ();
				// 		cell.Add (finalStringRightup);
				// 	}

				// 	if (intsecond - 1 >= 1) {

				// 		String finalStringRightdown = stringRight + leftrightintdown.ToString ();
				// 		cell.Add (finalStringRightdown);
				// 	}
				// }

		

				// foreach (String prefecs in cell) {

				// 	if (prefecs != null) {

				// 		if (GameObject.Find (prefecs).GetComponent<Cell> ().stoitfigura == true) {

				// 			// 	 if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex1 == true && GameObject.Find(prefecs).GetComponent<Cell>().figeureName.Contains("white")
				// 			//  || GameObject.Find("Camera").GetComponent<Xod>().StartIndex2 == true && GameObject.Find(prefecs).GetComponent<Cell>().figeureName.Contains("black")){
				// 			//  konecCiklaCelldigitIntPlus = false;
				// 			//  break;
				// 			//  }

				// 			if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 == true && GameObject.Find (prefecs).GetComponent<Cell> ().figeureName.Contains ("white") ||
				// 				GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == true && GameObject.Find (prefecs).GetComponent<Cell> ().figeureName.Contains ("black")) {
				// 				GameObject.Find (prefecs).GetComponent<Outline> ().enabled = true;
				// 				GameObject.Find (prefecs).GetComponent<Outline> ().color = 0;
				// 				GameObject.Find (prefecs).GetComponent<Cell> ().cell = false;
				// 				GameObject.Find (prefecs).GetComponent<Cell> ().cellvibranadlaxoda = true;
				// 				//  konecCiklaCelldigitIntPlus = false;
				// 				//  break;
				// 			}
				// 		}

				// 		if (GameObject.Find (prefecs).GetComponent<Cell> ().stoitfigura == false) {
				// 			GameObject.Find (prefecs).GetComponent<Outline> ().enabled = true;
				// 			GameObject.Find (prefecs).GetComponent<Outline> ().color = 1;
				// 			GameObject.Find (prefecs).GetComponent<Cell> ().cell = false;
				// 			GameObject.Find (prefecs).GetComponent<Cell> ().cellvibranadlaxoda = true;
				// 		}
				// 	}
				// }

				PereborMassiva (cell);
				cell.Clear ();;
				gameObject.GetComponent<Figure> ().camera.GetComponent<Moves> ().enabled = false;
				gameObject.GetComponent<Figure> ().moves = false;
			}

			#endregion

			#region Bishop			
			if (gameObject.GetComponent<Figure> ().choisefigure.name.Contains ("bishop")) {

				String s = gameObject.GetComponent<Figure> ().choisefigure.GetComponent<Trig> ().triger.name;
				String first = s.Substring (0, 1);
				String stringsecond = s.Substring (1, 1);
				int a = Int32.Parse (stringsecond);
				int b = Array.IndexOf (gameObject.GetComponent<HiddenGO> ().letters, first);
				ArrayList cell = new ArrayList ();

				for (int i = 1; i < 8; i++) {

					int c = b + i;

					if (c <= 7) {

						String e = gameObject.GetComponent<HiddenGO> ().letters[c];
						int r = a + i;

						if (r <= 8) {

							String upright = e + r.ToString ();
							cell.Add (upright);
						}
					}
				}

				PereborMassiva (cell);
				cell.Clear ();

				for (int i = 1; i < 8; i++) {

					int c = b + i;

					if (c <= 7) {

						String e = gameObject.GetComponent<HiddenGO> ().letters[c];
						int t = a - i;

						if (t >= 1) {

							String downright = e + t.ToString ();
							cell.Add (downright);
						}
					}
				}

				PereborMassiva (cell);
				cell.Clear ();

				for (int i = 1; i < 8; i++) {
					int g = b - i;

					if (g >= 0) {

						String h = gameObject.GetComponent<HiddenGO> ().letters[g];
						int u = a + i;
						if (u <= 8) {

							String upleft = h + u.ToString ();
							cell.Add (upleft);
						}
					}
				}

				PereborMassiva (cell);
				cell.Clear ();

				for (int i = 1; i < 8; i++) {
					int g = b - i;

					if (g >= 0) {

						String h = gameObject.GetComponent<HiddenGO> ().letters[g];
						int m = a - i;
						if (m >= 1) {
							String downleft = h + m.ToString ();
							cell.Add (downleft);
						}
					}
				}

				PereborMassiva (cell);
				cell.Clear ();;
				gameObject.GetComponent<Figure> ().camera.GetComponent<Moves> ().enabled = false;
				gameObject.GetComponent<Figure> ().moves = false;
			}

			#endregion

			#region  Queen		
			if (gameObject.GetComponent<Figure> ().choisefigure.name.Contains ("queen")) {

				String s = gameObject.GetComponent<Figure> ().choisefigure.GetComponent<Trig> ().triger.name;
				String first = s.Substring (0, 1);
				int b = (int) (Convert.ToChar (first) - '0');
				int d = Array.IndexOf (gameObject.GetComponent<HiddenGO> ().letters, first);
				String stringsecond = s.Substring (1, 1);
				int intsecond = Int32.Parse (stringsecond);
				int a = Int32.Parse (stringsecond);
				bool left = true;
				bool right = true;
				bool konecCiklaCelldigitIntPlus = true;
				bool konecCiklaCelldigitIntMinus = true;
				ArrayList cell = new ArrayList ();

				for (int v = 1; v < 8; v++) {

					if (right) {
						int p = b + v;
						char u = (char) (p + '0');
						String e = u.ToString ();
						String l = e + intsecond;
						Debug.Log ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
						Debug.Log (l);
						if (p < 17 || p > 24) {
							right = false;
							break;
						}
						cell.Add (l);
					}
				}

				PereborMassiva (cell);
				cell.Clear ();

				for (int k = 1; k < 8; k++) {

					if (left) {
						int o = b - k;
						char x = (char) (o + '0');
						String n = x.ToString ();
						String z = n + intsecond;
						Debug.Log ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
						Debug.Log (z);
						if (o < 17 || o > 24) {
							left = false;
							break;
						}
						cell.Add (z);

					}
				}

				PereborMassiva (cell);
				cell.Clear ();

				for (int i = 1; i < 8; i++) {
					if (konecCiklaCelldigitIntPlus) {
						int p = intsecond + i;
						String e = p.ToString ();
						String l = first + e;
						Debug.Log ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
						Debug.Log (l);
						if (l.Contains ("9")) {
							konecCiklaCelldigitIntPlus = false;
							break;
						}
						cell.Add (l);
					}
				}

				PereborMassiva (cell);
				cell.Clear ();

				for (int m = 1; m < 8; m++) {
					if (konecCiklaCelldigitIntMinus) {
						int p = intsecond - m;
						String e = p.ToString ();
						String l = first + e;
						Debug.Log ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
						Debug.Log (l);
						if (l.Contains ("0")) {
							konecCiklaCelldigitIntPlus = false;
							break;
						}
						cell.Add (l);
					}
				}

				PereborMassiva (cell);
				cell.Clear ();

				for (int i = 1; i < 8; i++) {

					int c = d + i;

					if (c <= 7) {

						String e = gameObject.GetComponent<HiddenGO> ().letters[c];
						int r = a + i;

						if (r <= 8) {

							String upright = e + r.ToString ();
							cell.Add (upright);
						}
					}
				}

				PereborMassiva (cell);
				cell.Clear ();

				for (int i = 1; i < 8; i++) {

					int c = d + i;

					if (c <= 7) {

						String e = gameObject.GetComponent<HiddenGO> ().letters[c];
						int t = a - i;

						if (t >= 1) {

							String downright = e + t.ToString ();
							cell.Add (downright);
						}
					}
				}

				PereborMassiva (cell);
				cell.Clear ();

				for (int i = 1; i < 8; i++) {
					int g = d - i;

					if (g >= 0) {

						String h = gameObject.GetComponent<HiddenGO> ().letters[g];
						int u = a + i;
						if (u <= 8) {

							String upleft = h + u.ToString ();
							cell.Add (upleft);
						}
					}
				}

				PereborMassiva (cell);
				cell.Clear ();

				for (int i = 1; i < 8; i++) {
					int g = d - i;

					if (g >= 0) {

						String h = gameObject.GetComponent<HiddenGO> ().letters[g];
						int m = a - i;
						if (m >= 1) {
							String downleft = h + m.ToString ();
							cell.Add (downleft);
						}
					}
				}

				PereborMassiva (cell);
				cell.Clear ();;

				gameObject.GetComponent<Figure> ().camera.GetComponent<Moves> ().enabled = false;
				gameObject.GetComponent<Figure> ().moves = false;
			}

			#endregion

			#region King		
			if (gameObject.GetComponent<Figure> ().choisefigure.name.Contains ("king")) {

				String s = gameObject.GetComponent<Figure> ().choisefigure.GetComponent<Trig> ().triger.name;
				String first = s.Substring (0, 1);
				String stringsecond = s.Substring (1, 1);
				int intsecond = Int32.Parse (stringsecond);
				int b = (int) (Convert.ToChar (first) - '0');
				// int b = Array.IndexOf (gameObject.GetComponent<HiddenGO> ().letters, first);
				ArrayList cell = new ArrayList ();
				int upint = intsecond + 1;
				int downint = intsecond - 1;

				if (intsecond + 1 <= 8) {

					String finalUp = first + upint.ToString ();
					cell.Add (finalUp);
				}

				PereborMassiva (cell);
				cell.Clear ();

				if (intsecond - 1 >= 1) {

					String finalDown = first + downint.ToString ();
					cell.Add (finalDown);
				}

				PereborMassiva (cell);
				cell.Clear ();

				int p = b + 1;
				Debug.Log ("*********************************" + p);
				int n = b - 1;
				Debug.Log ("*********************************" + n);

				if (p > 17 && p < 24) {
					char u = (char) (p + '0');
					String e = u.ToString ();
					String l = e + intsecond;
					Debug.Log ("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" + l);
					cell.Add (l);

					PereborMassiva (cell);
					cell.Clear ();

					if (intsecond + 1 <= 8) {

						String finalUp = e + upint.ToString ();
						cell.Add (finalUp);
						PereborMassiva (cell);
						cell.Clear ();
					}

					if (intsecond - 1 >= 1) {

						String finalDown = e + downint.ToString ();
						cell.Add (finalDown);
						PereborMassiva (cell);
						cell.Clear ();
					}

				}

				PereborMassiva (cell);
				cell.Clear ();

				if (n > 17 && n < 24) {
					char y = (char) (n + '0');
					String o = y.ToString ();
					String f = o + intsecond;
					Debug.Log ("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" + f);
					cell.Add (f);
					PereborMassiva (cell);
					cell.Clear ();
					if (intsecond + 1 <= 8) {

						String finalUp = o + upint.ToString ();
						cell.Add (finalUp);
						PereborMassiva (cell);
						cell.Clear ();
					}

					if (intsecond - 1 >= 1) {

						String finalDown = o + downint.ToString ();
						cell.Add (finalDown);
						PereborMassiva (cell);
						cell.Clear ();
					}
				}

				PereborMassiva (cell);
				cell.Clear ();

				gameObject.GetComponent<Figure> ().camera.GetComponent<Moves> ().enabled = false;
				gameObject.GetComponent<Figure> ().moves = false;
			}
			#endregion
		}
	}

	private void PereborMassiva (ArrayList cell) {

		bool konecCikla = false;
		foreach (String prefecs in cell) {

			if (prefecs != null) {
				if (konecCikla == false) {

					if (GameObject.Find (prefecs).GetComponent<Cell> ().stoitfigura == true) {

						if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == true && GameObject.Find (prefecs).GetComponent<Cell> ().figeureName.Contains ("white") ||
							GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 == true && GameObject.Find (prefecs).GetComponent<Cell> ().figeureName.Contains ("black")) {
							konecCikla = true;
							break;
						}

						if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 == true && GameObject.Find (prefecs).GetComponent<Cell> ().figeureName.Contains ("white") ||
							GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == true && GameObject.Find (prefecs).GetComponent<Cell> ().figeureName.Contains ("black")) {
							GameObject.Find (prefecs).GetComponent<Outline> ().enabled = true;
							GameObject.Find (prefecs).GetComponent<Outline> ().color = 0;
							GameObject.Find (prefecs).GetComponent<Cell> ().cell = false;
							GameObject.Find (prefecs).GetComponent<Cell> ().cellvibranadlaxoda = true;
							konecCikla = true;
							break;
						}
					}

					if (GameObject.Find (prefecs).GetComponent<Cell> ().stoitfigura == false) {
						GameObject.Find (prefecs).GetComponent<Outline> ().enabled = true;
						GameObject.Find (prefecs).GetComponent<Outline> ().color = 1;
						GameObject.Find (prefecs).GetComponent<Cell> ().cell = false;
						GameObject.Find (prefecs).GetComponent<Cell> ().cellvibranadlaxoda = true;
					}
				}
			}
		}
	}
}