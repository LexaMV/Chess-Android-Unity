using System;
using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

public class Moves: MonoBehaviour {

	void Update() {
		if (gameObject.GetComponent < Figure > ().moves) {


			// if (gameObject.GetComponent < Figure > ().choisefigure.name.Contains("pawn")) {
			// 	String s = gameObject.GetComponent < Figure > ().choisefigure.GetComponent < Trig > ().triger.name;
			// 	String first = s.Substring(0, 1);

			// 	String stringsecond = s.Substring(1, 1);

			// 	int intsecond = Int32.Parse(stringsecond);

			// 	int intsecond1 = 0;
			// 	int intsecond2 = 0;

			// 	if (intsecond < 4) {
			// 		intsecond1 = intsecond + 1;
			// 		intsecond2 = intsecond + 2;
			// 	} else if (intsecond > 4) {
			// 		intsecond1 = intsecond - 1;
			// 		intsecond2 = intsecond - 2;
			// 	}

			// 	String final1 = first + intsecond1.ToString();

			// 	String final2 = first + intsecond2.ToString();

			// 	GameObject.Find(s).GetComponent < Outline > ().enabled = true;
			// 	GameObject.Find(s).GetComponent < Cell > ().cell = false;
			// 	GameObject.Find(final1).GetComponent < Outline > ().enabled = true;
			// 	GameObject.Find(final1).GetComponent < Cell > ().cell = false;
			// 	GameObject.Find(final2).GetComponent < Outline > ().enabled = true;
			// 	GameObject.Find(final2).GetComponent < Cell > ().cell = false;
			// 	gameObject.GetComponent < Figure > ().camera.GetComponent < Moves > ().enabled = false;
			// 	gameObject.GetComponent < Figure > ().moves = false;
			// }

			// if (gameObject.GetComponent < Figure > ().choisefigure.name.Contains("rook")) {
			// 	String s = gameObject.GetComponent < Figure > ().choisefigure.GetComponent < Trig > ().triger.name;
			// 	String first = s.Substring(0, 1);


			// 	String stringsecond = s.Substring(1, 1);


			// 	int intsecond = Int32.Parse(stringsecond);
			// 	ArrayList cell = new ArrayList();
			// 	foreach(String prefecs in gameObject.GetComponent < HiddenGO > ().letters) {
			// 		String g = prefecs + stringsecond;
			// 		cell.Add(g);
			// 	}

			// 	foreach(String prefecs in gameObject.GetComponent < HiddenGO > ().digit) {
			// 		String g = first + prefecs;
			// 		cell.Add(g);
			// 	}

			// 	foreach(String prefecs in cell) {
			// 		GameObject.Find(prefecs).GetComponent < Outline > ().enabled = true;
			// 		GameObject.Find(prefecs).GetComponent < Cell > ().cell = false;;
			// 	}

			// 	gameObject.GetComponent < Figure > ().camera.GetComponent < Moves > ().enabled = false;
			// 	gameObject.GetComponent < Figure > ().moves = false;

			// }


			if (gameObject.GetComponent < Figure > ().choisefigure.name.Contains("knight")) {
				String s = gameObject.GetComponent < Figure > ().choisefigure.GetComponent < Trig > ().triger.name;
				String first = s.Substring(0, 1);
				Debug.Log(first);
				String stringsecond = s.Substring(1, 1);



				int intsecond = Int32.Parse(stringsecond);
				int upint = intsecond + 2;
				int downint = intsecond - 2;
				int leftrightintup = intsecond + 1;
				int leftrightintdown = intsecond - 1;
				int b = Array.IndexOf(gameObject.GetComponent < HiddenGO > ().letters, first);

				ArrayList cell = new ArrayList();

				if (b - 1 > -1) {
					String upStringLeft = gameObject.GetComponent < HiddenGO > ().letters[b - 1];

					String finalUpStringLeft = upStringLeft + upint.ToString();

					String finalDownStringLeft = upStringLeft + downint.ToString();
					//    cell.Add(finalUpStringLeft);
					//    cell.Add(finalDownStringLeft);
				}

				if (b - 2 > -1) {
					String stringLeft = gameObject.GetComponent < HiddenGO > ().letters[b - 2];
					String finalStringLeftup = stringLeft + leftrightintup.ToString();
					String finalStringLeftdown = stringLeft + leftrightintdown.ToString();
					// cell.Add(finalStringLeftup);
					// cell.Add(finalStringLeftdown);
				}

				if (b + 1 < 8) {
					String upStringRight = gameObject.GetComponent < HiddenGO > ().letters[b + 1];
					Debug.Log(upStringRight);
					String finalUpStringRight = upStringRight + upint.ToString();
					Debug.Log(finalUpStringRight);
					String finalDownStringRight = upStringRight + downint.ToString();
					cell.Add(finalUpStringRight);
					// cell.Add(finalDownStringRight);
				}

				if (b + 2 < 8) {
					String stringRight = gameObject.GetComponent < HiddenGO > ().letters[b + 2];
					String finalStringRightup = stringRight + leftrightintup.ToString();
					String finalStringRightdown = stringRight + leftrightintdown.ToString();
					// cell.Add(finalStringRightup);
					// cell.Add(finalStringRightdown);
				}

				foreach(String prefecs in cell) {
					if (prefecs != null) {
						GameObject.Find(prefecs).GetComponent < Outline > ().enabled = true;
						GameObject.Find(prefecs).GetComponent < Cell > ().cell = false;
					}
				}

				gameObject.GetComponent < Figure > ().camera.GetComponent < Moves > ().enabled = false;
				gameObject.GetComponent < Figure > ().moves = false;

			}



			if (gameObject.GetComponent < Figure > ().choisefigure.name.Contains("bishop")) {
				String s = gameObject.GetComponent < Figure > ().choisefigure.GetComponent < Trig > ().triger.name;
				String first = s.Substring(0, 1);
				String stringsecond = s.Substring(1, 1);
				int a = Int32.Parse(stringsecond);
				int b = Array.IndexOf(gameObject.GetComponent < HiddenGO > ().letters, first);

				ArrayList cell = new ArrayList();

				for (int i = 1; i < 8; i++) {
					int c = b + i;
					if (c < gameObject.GetComponent < HiddenGO > ().letters.Length) {
						String e = gameObject.GetComponent < HiddenGO > ().letters[c];
						int r = a + i;
						String upright = e + r.ToString();
						int t = a - i;
						String downright = e + t.ToString();
						cell.Add(upright);
						cell.Add(downright);
					} else continue;





					int g = b - i;
					if (g >= 0) {
						String h = gameObject.GetComponent < HiddenGO > ().letters[g];
						int u = a + i;
						int m = a - i;
						String upleft = h + u.ToString();
						String downleft = h + m.ToString();
						cell.Add(upleft);
						cell.Add(downleft);
					} else continue;





				}



				foreach(String prefecs in cell) {
					GameObject.Find(prefecs).GetComponent < Outline > ().enabled = true;
					GameObject.Find(prefecs).GetComponent < Cell > ().cell = false;;
				}

				gameObject.GetComponent < Figure > ().camera.GetComponent < Moves > ().enabled = false;
				gameObject.GetComponent < Figure > ().moves = false;

			}


			if (gameObject.GetComponent < Figure > ().choisefigure.name.Contains("queen")) {
				String s = gameObject.GetComponent < Figure > ().choisefigure.GetComponent < Trig > ().triger.name;
				String first = s.Substring(0, 1);


				String stringsecond = s.Substring(1, 1);


				int intsecond = Int32.Parse(stringsecond);
				ArrayList cell = new ArrayList();
				foreach(String prefecs in gameObject.GetComponent < HiddenGO > ().letters) {
					String g = prefecs + stringsecond;
					cell.Add(g);
				}

				foreach(String prefecs in gameObject.GetComponent < HiddenGO > ().digit) {
					String g = first + prefecs;
					cell.Add(g);
				}


				int a = Int32.Parse(stringsecond);
				int b = Array.IndexOf(gameObject.GetComponent < HiddenGO > ().letters, first);

				for (int i = 1; i < 8; i++) {
					int c = b + i;
					if (c < gameObject.GetComponent < HiddenGO > ().letters.Length) {
						String e = gameObject.GetComponent < HiddenGO > ().letters[c];
						int r = a + i;
						String upright = e + r.ToString();
						int t = a - i;
						String downright = e + t.ToString();
						cell.Add(upright);
						cell.Add(downright);
					} else continue;



					int g = b - i;
					if (g >= 0) {
						String h = gameObject.GetComponent < HiddenGO > ().letters[g];
						int u = a + i;
						int m = a - i;
						String upleft = h + u.ToString();
						String downleft = h + m.ToString();
						cell.Add(upleft);
						cell.Add(downleft);
					} else continue;



					foreach(String prefecs in cell) {
						GameObject.Find(prefecs).GetComponent < Outline > ().enabled = true;
						GameObject.Find(prefecs).GetComponent < Cell > ().cell = false;;
					}




					gameObject.GetComponent < Figure > ().camera.GetComponent < Moves > ().enabled = false;
					gameObject.GetComponent < Figure > ().moves = false;
				}
			}



			if (gameObject.GetComponent < Figure > ().choisefigure.name.Contains("king")) {

				String s = gameObject.GetComponent < Figure > ().choisefigure.GetComponent < Trig > ().triger.name;
				String first = s.Substring(0, 1);

				String stringsecond = s.Substring(1, 1);



				int intsecond = Int32.Parse(stringsecond);

				int up = intsecond + 1;
				int down = intsecond - 1;
				int b = Array.IndexOf(gameObject.GetComponent < HiddenGO > ().letters, first);

				ArrayList cell = new ArrayList();

				if (b - 1 > -1) {
					String Left = gameObject.GetComponent < HiddenGO > ().letters[b - 1];

					String LeftCell = Left + stringsecond;
					String LeftCellUp = Left + up.ToString();
					String LeftCellDown = Left + down.ToString();

					cell.Add(LeftCell);
					cell.Add(LeftCellUp);
					cell.Add(LeftCellDown);
				}

				if (b + 1 < 8) {
					String Right = gameObject.GetComponent < HiddenGO > ().letters[b + 1];

					String RightCell = Right + stringsecond;
					String RightCellUp = Right + up.ToString();
					String RightCellDown = Right + down.ToString();

					cell.Add(RightCell);
					cell.Add(RightCellUp);
					cell.Add(RightCellDown);
				}


				foreach(String prefecs in cell) {
					if (prefecs != null) {
						GameObject.Find(prefecs).GetComponent < Outline > ().enabled = true;
						GameObject.Find(prefecs).GetComponent < Cell > ().cell = false;;
					}
				}

				gameObject.GetComponent < Figure > ().camera.GetComponent < Moves > ().enabled = false;
				gameObject.GetComponent < Figure > ().moves = false;

			}
		}
	}

	}
