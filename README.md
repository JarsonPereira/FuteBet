
<h1> FuteBet - Uma aplicação para apostas </h1>
<h5>Por: Jarson Oliveira</h5>
<img  src="https://apostasonline.pt/wp-content/uploads/2017/07/apostasonline_logo.svg"/>
<ul>
<li><h3>CQRS</h3></li>
<li><h3>DDD</h3></li>
<li><h3>IOC</h3></li>
<li><h3>Distributed Cache</h3></li>
</ul>

CartolaFC API (2016 / 2017)
Status do mercado

https://api.cartolafc.globo.com/mercado/status

Lista dos jogadores mais escalados

https://api.cartolafc.globo.com/mercado/destaques

Lista de patrocinadores

https://api.cartolafc.globo.com/patrocinadores

Lista das rodadas do campeonato (1 até 38)

https://api.cartolafc.globo.com/rodadas

Próximas partidas do campeonato

https://api.cartolafc.globo.com/partidas

Partidas da rodada

https://api.cartolafc.globo.com/partidas/[rodada]

Lista de clubes

https://api.cartolafc.globo.com/clubes

Lista de todos os jogadores (retorna todas as informações)

https://api.cartolafc.globo.com/atletas/mercado

Pontuação da rodada em andamento

https://api.cartolafc.globo.com/atletas/pontuados

Time que mais pontuou na rodada anterior

https://api.cartolafc.globo.com/pos-rodada/destaques

Busca geral de times, vai retornar info do time e o slug

https://api.cartolafc.globo.com/times?q=[nome do time]

Busca informações de um time específico, usar o slug do time.

https://api.cartolafc.globo.com/time/slug/[slug do time]

Busca informações de um time específico por rodada, usar o slug do time e o número da rodada (ex. 1,2,3,4...)

https://api.cartolafc.globo.com/time/slug/[slug do time]/[rodada]

Busca geral de ligas, para consultar uma liga específica é necessário token

https://api.cartolafc.globo.com/ligas?q=[nome da liga]

Busca informações de uma liga específica, usar o slug da liga.

https://api.cartolafc.globo.com/auth/liga/[slug da liga]

Retornar informações do time do usuario logado.

https://api.cartolafc.globo.com/auth/time

https://api.cartolafc.globo.com/auth/time/info

Retornar todas as ligas do usuário logado.

https://api.cartolafc.globo.com/auth/ligas

Lista os esquemas táticos (4-3-3) etc...

https://api.cartolafc.globo.com/esquemas

Salvar a escalação do time. (requer autenticação)

Enviar um POST para esse endpoint. Também é necessário enviar no header o "X-GLB-Token" com o token.

https://api.cartolafc.globo.com/auth/time/salvar

O POST deve conter o seguinte o códido do esquema tático e os códigos dos atletas:

 [
 	"esquema": 3,
 	"atleta": [
 		37788,
 		71116,
 		39152,
 		50427,
 		87225,
 		62009,
 		81682,
 		87863,
 		78435,
 		68930,
 		90651,
 		62136
 	]
 ]
Posições e Status dos atletas

{
   "posicoes":[
      {
         "id":1,
         "nome":"Goleiro",
         "abreviacao":"gol"
      },
      {
         "id":3,
         "nome":"Zagueiro",
         "abreviacao":"zag"
      },
      {
         "id":2,
         "nome":"Lateral",
         "abreviacao":"lat"
      },
      {
         "id":4,
         "nome":"Meia",
         "abreviacao":"mei"
      },
      {
         "id":5,
         "nome":"Atacante",
         "abreviacao":"ata"
      },
      {
         "id":6,
         "nome":"Técnico",
         "abreviacao":"tec"
      }
   ],
   "status":[
      {
         "id":7,
         "nome":"Provável",
         "slug":"provavel"
      },
      {
         "id":5,
         "nome":"Contudido",
         "slug":"contundido"
      },
      {
         "id":2,
         "nome":"Dúvida",
         "slug":"duvida"
      },
      {
         "id":3,
         "nome":"Suspenso",
         "slug":"suspenso"
      },
      {
         "id":6,
         "nome":"Nulo",
         "slug":"nulo"
      }
   ]
}
