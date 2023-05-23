import java.io.File;  // Import the File class
import java.io.FileNotFoundException;  // Import this class to handle errors
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner; // Import the Scanner class to read text files

public class Editor {

	public static void main(String[] args) throws FileNotFoundException {
		
		String title = "black";
		String BG = "000000";
		String Path = "000000";
		String BGEmpty = "000000";
		String BGDeep = "000000";
		String EStroke = "000000";


		String[] Stone = new String[3];
		Stone[0] = "000000";
		Stone[1] = "000000";
		Stone[2] = "000000";

		String[] Detail = new String[3];
		Detail[0] = "000000";
		Detail[1] = "000000";
		Detail[2] = "000000";

		String[] StoneEmpty = new String[3];
		StoneEmpty[0] = "000000";
		StoneEmpty[1] = "000000";
		StoneEmpty[2] = "000000";

		String[] DetailEmpty = new String[3];
		DetailEmpty[0] = "000000";
		DetailEmpty[1] = "000000";
		DetailEmpty[2] = "000000";

		String[] StoneDeep = new String[3];
		StoneDeep[0] = "000000";
		StoneDeep[1] = "000000";
		StoneDeep[2] = "000000";

		String[] DetailDeep = new String[3];
		DetailDeep[0] = "000000";
		DetailDeep[1] = "000000";
		DetailDeep[2] = "000000";

//		newTexture( title,  BG,  Path,  BGEmpty,  BGDeep,  EStroke, Stone,  Detail,  StoneEmpty,  DetailEmpty,  StoneDeep,  DetailDeep);

		
		
		Scanner Loader = new Scanner(new File("svg.txt"));
		Scanner Searcher = new Scanner (System.in);
		String dT = Searcher.next();
		int l = 0;
		int i = 0;
		List<String> items = new ArrayList<String>(); 
		while (Loader.hasNextLine()){
			items.add(Loader.nextLine());
			
			//System.out.println(l+" "+items.get(l));
			if(items.get(l).contains(dT)) {
				//System.out.println(l);
			i = l;	
			}
			l++;
		}
			//System.out.println(items.get(i));
					title = items.get(i); /// hier Items betrachten
					BG = items.get(i+1);
					Path = items.get(i+2);
					BGEmpty =items.get(i+3);
					BGDeep = items.get(i+4);
					EStroke = items.get(i+5);

					Stone[0] = items.get(i+6);
					Stone[1] = items.get(i+7);
					Stone[2] = items.get(i+8);

					Detail[0] = items.get(i+9);
					Detail[1] = items.get(i+10);
					Detail[2] = items.get(i+11);

					StoneEmpty[0] = items.get(i+12);
					StoneEmpty[1] = items.get(i+13);
					StoneEmpty[2] = items.get(i+14);

					DetailEmpty[0] = items.get(i+15);
					DetailEmpty[1] = items.get(i+16);
					DetailEmpty[2] = items.get(i+17);

					StoneDeep[0] = items.get(i+18);
					StoneDeep[1] = items.get(i+19);
					StoneDeep[2] = items.get(i+20);

					DetailDeep[0] = items.get(i+21);
					DetailDeep[1] = items.get(i+22);
					DetailDeep[2] = items.get(i+23);
			
			

		File originPDir = new File("..\\Assets\\0 Spielfeld\\Path\\classic");
		new File(originPDir.toString().replace("classic", title)).mkdirs(); // erstelle neues Verzeichnis (bspw halloween)
		File originTDir = new File("..\\Assets\\0 Spielfeld\\Tiles\\classic");
		new File(originTDir.toString().replace("classic", title)).mkdirs();

		File[] originPaths = originPDir.listFiles((dir1, name) -> name.endsWith(".svg"));
		File[] originTiles = originTDir.listFiles((dir1, name) -> name.endsWith(".svg")&&name.startsWith("Empty"));
		File originBG = new File("..\\Assets\\0 Spielfeld\\Background\\classic.svg");
		File originBGDeep = new File("..\\Assets\\0 Spielfeld\\Background\\classicDeep.svg");

		Path(originPaths, title, BG, Path, Stone, Detail); // Hexagon 2px, Path 1px, Stone 0.5px, Detail 0.25px
		//Empty(originTiles, title, BGEmpty, StoneEmpty, DetailEmpty, EStroke);
		//BG(originBG, title, BGDeep, StoneDeep, DetailDeep);
		//BG(originBGDeep, title, BGDeep, StoneDeep, DetailDeep);
	}

	public static void Path(File[] files,String title, String BG,String Path,String[] Stone,String[] Detail) {
		String sub = "";
		String newPath = "";
		FileWriter newFile;

		try {
			for (int i = 0; i<files.length; i++) {
				newPath = files[i].toString().replace("classic", title);
				//System.out.println(files[i]);
				Scanner Reader = new Scanner(files[i]);
				try {
					newFile = new FileWriter(newPath);
					while (Reader.hasNextLine()) {
						String text = Reader.nextLine();
						if(text.contains("#")) {
							int start = text.indexOf('#')+1;
							if(start>=0) {
								sub = text.substring(start,start+6);
							}
						}
						//Background
						text = text.replace("#"+sub+";stroke:#000000;stroke-width:2;","#"+BG+";stroke:#000000;stroke-width:2;");
						//Path
						text = text.replace("#"+sub+";stroke:#000000;stroke-miterlimit:10;","#"+Path+";stroke:#000000;stroke-miterlimit:10;");
						//Stones
						text = text.replace("#"+sub+";stroke:#000000;stroke-width:0.5;","#"+Stone[(int) Math.floor(Math.random()*3)]+";stroke:#000000;stroke-width:0.5;");
						//Details
						text = text.replace("#"+sub+";stroke:#000000;stroke-width:0.25;","#"+Detail[(int) Math.floor(Math.random()*3)]+";stroke:#000000;stroke-width:0.25;");

						newFile.write(text);
						newFile.flush();
					}

					newFile.close();
				} catch (IOException e) {
					System.out.println("Error");
					e.printStackTrace();
				} // Ends Try Catch Writer
				Reader.close();

			}

		} catch (FileNotFoundException e) {
			System.out.println("An error occurred.");
			e.printStackTrace();
		}
	}

	public static void Empty(File[] files,String title, String BG,String[] Stone,String[] Detail, String Stroke) {
		String sub = "";
		String newPath = "";
		FileWriter newFile;
		System.out.println(files[0]);
		try {
			for (int i = 0; i<files.length; i++) {
				newPath = files[i].toString().replace("classic", title);
				System.out.println(files[i]);
				Scanner Reader = new Scanner(files[i]);
				try {
					newFile = new FileWriter(newPath);
					while (Reader.hasNextLine()) {
						String text = Reader.nextLine();
						if(text.contains("#")) {
							int start = text.indexOf('#')+1;
							if(start>=0) {
								sub = text.substring(start,start+6);
							}
						}
						//Background
						text = text.replace("#"+sub+";stroke:#000000;stroke-width:2;","#"+BG+";stroke:#"+Stroke+";stroke-width:2;");
						//Stones
						text = text.replace("#"+sub+";stroke:#000000;stroke-width:0.5;","#"+Stone[(int) Math.floor(Math.random()*3)]+";stroke:#"+Stroke+";stroke-width:0.5;");
						//Details
						text = text.replace("#"+sub+";stroke:#000000;stroke-width:0.25;","#"+Detail[(int) Math.floor(Math.random()*3)]+";stroke:#000000;stroke-width:0.25;");

						newFile.write(text);
						newFile.flush();
					}

					newFile.close();
				} catch (IOException e) {
					System.out.println("Error");
					e.printStackTrace();
				} // Ends Try Catch Writer
				Reader.close();

			}

		} catch (FileNotFoundException e) {
			System.out.println("An error occurred.");
			e.printStackTrace();
		}
	}

	public static void BG(File file,String title, String BG,String[] Stone,String[] Detail) {
		String sub = "";
		FileWriter newFile = null;
		try {
			newFile = new FileWriter(file.toString().replace("classic", title));
		} catch (IOException e) {
			System.out.println("Error");
			e.printStackTrace();
		}
		try {
			try (Scanner Reader = new Scanner(file)) {
				while (Reader.hasNextLine()) {
					String text = Reader.nextLine();

					if(text.contains("#")) {
						int start = text.indexOf('#')+1;

						if(start>=0) {
							sub = text.substring(start,start+6);
						}
					}
					//Background
					text = text.replace("#"+sub+";stroke:#000000;stroke-width:6;","#"+BG+";stroke:#000000;stroke-width:6;"); //approved
					//Stones
					text = text.replace("#"+sub+";stroke:#000000;stroke-miterlimit:10;","#"+Stone[(int) Math.floor(Math.random()*3)]+";stroke:#000000;stroke-miterlimit:10;");
					//Details
					text = text.replace("#"+sub+";stroke:#000000;stroke-width:0.5;","#"+Detail[(int) Math.floor(Math.random()*3)]+";stroke:#000000;stroke-width:0.5;");

					newFile.write(text);
					newFile.flush();
				}
			}
		} catch (IOException e1) {
			System.out.println("Error");
			e1.printStackTrace();
		}
	}

	static void newTexture(String title, String BG, String Path, String BGEmpty, String BGDeep, String EStroke,String[] Stone, String[] Detail, String[] StoneEmpty, String[] DetailEmpty, String[] StoneDeep, String[] DetailDeep){

		try {
			FileWriter newTexture = new FileWriter(new File("svg.txt"));
			newTexture.write(title+"\n");
			newTexture.write(BG+"\n");
			newTexture.write(Path+"\n");
			newTexture.write(BGEmpty+"\n");
			newTexture.write(BGDeep+"\n");
			newTexture.write(EStroke+"\n");
			newTexture.write(Stone[0]+"\n");
			newTexture.write(Stone[1]+"\n");
			newTexture.write(Stone[2]+"\n");
			newTexture.write(Detail[0]+"\n");
			newTexture.write(Detail[1]+"\n");
			newTexture.write(Detail[2]+"\n");
			newTexture.write(StoneEmpty[0]+"\n");
			newTexture.write(StoneEmpty[1]+"\n");
			newTexture.write(StoneEmpty[2]+"\n");
			newTexture.write(DetailEmpty[0]+"\n");
			newTexture.write(DetailEmpty[1]+"\n");
			newTexture.write(DetailEmpty[2]+"\n");
			newTexture.write(StoneDeep[0]+"\n");
			newTexture.write(StoneDeep[1]+"\n");
			newTexture.write(StoneDeep[2]+"\n");
			newTexture.write(DetailDeep[0]+"\n");
			newTexture.write(DetailDeep[1]+"\n");
			newTexture.write(DetailDeep[2]+"\n");
			newTexture.flush();
		} catch (IOException e) {
			System.out.println("Error");
			e.printStackTrace();
		};
	}
}


