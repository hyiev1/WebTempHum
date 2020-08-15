
import java.awt.Dimension;
import java.io.*;
import java.net.*;

import java.io.Console;
import java.io.IOException;

import myTemp.myTemperature;
import myHum.myHumidity;


public class main {
	
	public static void main(String []args) throws IOException {
		String outmyTemp;
		String outmyHum;
		
		for(int i = 0; i <= 100; i = 1) {
			outmyTemp = myTemperature.myTemp();
			outmyHum = myHumidity.myHum();
			System.out.println("Dein Raum: ");
			System.out.println("Temperatur: " + outmyTemp + " Grad Celsius");
			System.out.println("Luftfeuchtigkeit: " + outmyHum + " %");
			System.out.println();
			
			
			
			try {
				Thread.sleep(10000);
			} catch (InterruptedException e) {
				e.printStackTrace(); 
				System.out.println("Fehler: " + e);
			} 
			
			//clearScreen();
			System.out.println();
			
		} 	
	}
	
		
    public static void clearScreen() {
    System.out.print("\033[H\033[2J");
    System.out.flush();
    }

}
 