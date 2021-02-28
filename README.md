# WebTempHumidity

## How it works

```bash
	+------------------------+
	| ESP8266 & DHT-Sensor	 |
	|  - updates information |
	|	on request	 |
	+------------------------+
		 ^
   	  [hosts & updates]
		 v
	+----------------+
	| Webserver 	 |
	|  - Json format |
	+----------------+
		 ^
      	     [requests]
		 |
	+---------------------------------+
	| WebClient (C#/Java)		  |
	|  - requests & Shows Information |
	+---------------------------------+
```
