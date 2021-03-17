import requests
import time
import colorama

def get_webserver() -> str:
    webserver = None
    while True:
        print(F"Enter the IP address of the webserver (\"http://XX.XX.XX.XX/info\"):")
        webserver = input()
        print(f"Set to: \"{webserver}\"\n")
        if (webserver.startswith("http://") or webserver.startswith("https://")) and webserver.endswith("/info"):
            print(f"Getting info from \"{webserver}\"")
            return webserver

def main():
    address = get_webserver()
    while True:
        try:
            information = requests.get(address)
            if information.status_code == 200:
                information_json = information.json()
                print("----- ----- ----- -----")
                #print(f"Raw: {information_json}")
                print(f"Temperature: {colorama.Fore.CYAN}{information_json['temperature']} °C{colorama.Fore.WHITE}")
                print(f"Humidity:    {colorama.Fore.CYAN}{information_json['humidity']} %{colorama.Fore.WHITE}")
            else:
                print(f"{colorama.Fore.RED}Failed{colorama.Fore.WHITE} to get information from \"{address}\".")
        except requests.ConnectionError:
            print(f"{colorama.Fore.RED}Error:{colorama.Fore.WHITE} {requests.ConnectionError}")
            print("\tMake sure that the webserver can be accessed.")
        time.sleep(10)

if __name__ == "__main__":
    main()