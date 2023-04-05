# MyUrlShorteningService

# URL shortening Service
Build a simple URL shortening Service. The service should be implemented as stand-alone application (preferable with .NET) and should provide the following features as 
# Restful API:
Shortening: Take a URL and return a much shorter URL.

 The input URL format must be valid

 Maximum character length for the hash portion of the URL is 6

 The Service should return a meaningful message with a suitable status code

Eg: https://www.sample-site.com/karriere/berufserfahrene/direkteinstieg/ =>
http://sample.site/GUKA8w/

Redirection: Take a short URL and redirect to the original URL.
Eg: http://sample.site/GUKA8w/ => https://www.sample-site.com/karriere/berufserfahrene/direkteinstieg/

Custom URL: Allow the users to pick custom shortened URL.
Eg: http://www.sample-site.com/karriere/jobsuche/ => http://sample.site/jobs

A frontend is not needed. As we just have a very small user base we do not need a 
scalable service. The URLs should be persisted permanent, so there should be no 
expiring feature. The data storage can be implemented as collection or embedded 
database. 