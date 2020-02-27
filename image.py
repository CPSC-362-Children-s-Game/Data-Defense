import urllib.request
import requests
import json
import os
import shutil

def read_file():
   return ['apple', 'car', 'keys']

def download_images(query, amount):
   url = f'https://pixabay.com/api/?key=15166612-8bcfb22d35cbe5fa10185ee62&q={query}&per_page={amount}&safesearch=true&image_type=vector'
   response = urllib.request.urlopen(url)

   data = json.load(response)

   hits = data['hits']

   count = 0
   for image in hits:
       count += 1

       request = requests.get(image['webformatURL'], stream=True)
       with open(f'assets//{query}{count}.png', 'wb') as f:
           request.raw.decode_content = True
           shutil.copyfileobj(request.raw, f)

def main():
   if not os.path.exists('assets'):
       os.mkdir('assets')

   data = read_file()

   for item in data:
       download_images(item, 3)
    
   return None
   
main()