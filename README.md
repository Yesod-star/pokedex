#pokedex

This is a pokedex API created using C# rest and using MongoDB and Docker, use it to create items, types, moves and pokemons for your game.

#How to use
To make sure the api is running, just install a docker and use the following command in your terminal:
-docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo

After this you will have the api running and you can create any item you want using postman or swagger in the following links:
http://localhost:5001/swagger/index.html
https://localhost:7246/api/
