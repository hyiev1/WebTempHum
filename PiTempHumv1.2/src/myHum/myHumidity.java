package myHum;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.NoSuchElementException;

public class myHumidity {
	public static String myHum() throws IOException {
		
    	@SuppressWarnings("null")
    		
            URL info = new URL("http://192.168.43.250/info");
            BufferedReader in = new BufferedReader(
            new InputStreamReader(info.openStream()));

            String inputLine;
            String myHum = "'kein Input'";
            while ((inputLine = in.readLine()) != null)
            	//System.out.println(inputLine);
            	myHum = inputLine.substring(38,40);
            	
            	//System.out.println("Temperatur: " + myTemp + "Grad Celsius");
            	
            	
            in.close();
			return myHum;
			
    }
}