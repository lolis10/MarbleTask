# MarbleTask

A tarefa cognitiva Marble Task (Want & Harris, 2001) é uma versão de uma tarefa de entendimento causal - TrapTube Task, que, por sua vez, é uma variação de uma tarefa piagetiana de causalidade. A Marble Task é destinada para crianças com idade entre 2-4 anos. O aparato consiste em uma casa-de-brinquedo com duas aberturas na parte superior e posicionadas em lados diametralmente opostos. Cada abertura leva a uma canaleta no interior do aparato, que se encontra com a canaleta da entrada oposta em um ponto central, e também a uma canaleta vertical que leva a uma portinhola posicionada na base do aparato (um formato do tipo “Y”).

Entre o ponto central e a portinhola, um pequeno alçapão serve de apoio para o objeto. O objeto é inacessível diretamente pela criança. Para retirar o objeto do interior do aparato, uma bola-de-gude é oferecida para criança, que deve colocá-la em um dentre as duas canaletas a fim de derrubar o objeto do alçapão e o retira-lo através da portinhola. Entretanto, em uma das duas entradas é posicionado um obstáculo, que impede que a bolinha alcance a região do alçapão no interior do aparato. Portanto, a criança colocar a bola na entrada cuja canaleta não está obstruída a fim de resgatar o objeto do interior do aparato.

# Materiais

- Kinect v2
- Kinect SDK For Windows 2.0
- Unity 3D
- Microsoft Visual Studio (ou alguma outra IDE de sua preferência)

# Scripts

Os scripts de códigos comentados encontram-se no caminho "Assets\Scripts" do repositório.

# Imagens

As imagens encontram-se em "Assets\Imagens".

# Cenas

As cenas encontram-se em "Assets\Scenes".

# Funcionamento

A aplicação inicia com a Tela de Configurações, que diz respeito à entrada de parâmetros para uma jogada. As escolhas dos parâmetros são definidas pelo orientador. As informações que devem ser preenchidas são:

-	Nome do Experimentador: refere-se ao nome do indivíduo que irá conduzir aquela jogada.
-	Nome do Sujeito: refere-se ao nome do indivíduo que será submetido a jogada.
-	Data de Nascimento: refere-se à data de nascimento do sujeito em formato numérico dd/mm/aaaa (onde dd, representa os dois dígitos referentes ao dia, mm refere-se aos dois dígitos do mês e aaaa refere-se aos 4 dígitos do ano de nascimento).
-	Número de tentativas: refere-se à quantidade de tentativas naquela jogada. A entrada de dados deve ser um número inteiro não negativo.
-	Treino: especifica se haverá uma cena de treino. Por padrão, a opção selecionada é não, podendo ser alterada para Sim caso seja determinado que haverá um treino naquela jogada.
-	Sexo: refere-se ao sexo do sujeito. As opções são: Masculino e Feminino.
-	Lateralidade: diz respeito a mão que será utilizada para as tentativas, podendo escolher Mão Direita ou Mão Esquerda.
-	Obstáculo: define o lado que o obstáculo da cena principal, podendo ser: Lado Direito, Lado Esquerdo ou Pseudoaleatório.


# Planilhas

	A finalização de uma jogada resulta na geração de duas planilhas em formato CSV. Uma diz respeito às informações de desempenho e a outra, de movimento.
  
Desempenho

	Para dados de desempenho, as informações gravadas na planilha foram:
-	Experimentador: refere-se à pessoa que esteve acompanhando a realização da tarefa.
-	Sujeito: refere-se à pessoa que foi submetida a realização da tarefa.
-	Meses: quantidade de meses do sujeito a partir da sua data de nascimento.
-	Tentativa: quantidade de tentativas naquela jogada.
-	Acerto(s): quantidade de tentativas em que houveram sucesso durante a jogada.
-	Erro(s): quantidade de tentativas em que houveram fracasso.
-	Lateralidade: refere-se a mão que foi utilizada para realizar a tarefa.
-	Lado do Obstáculo: verifica se, no momento da tentativa, o obstáculo se encontrava no lado direito ou esquerdo da tela.
-	Esperado: refere-se ao lado da chaminé em que se encontra livre a passagem para a bola.
-	Obtido: refere-se ao lado obtido naquela tentativa.
-	Data/Hora: diz respeito ao horário da realização da atividade.
-	Sexo: verifica se o sujeito é do sexo masculino ou feminino.
-	Tempo de reação: refere-se ao tempo do início da tentativa até que a bola seja coletada pelo jogador.
-	Tempo observado: refere-se ao tempo da tentativa a partir do tempo de reação.
-	Tempo total gasto: é o tempo gasto para realização de cada uma das tentativas.
-	Tempo com bola: tempo em que a bola se encontrava na mão durante as tentativas.
 
Movimento

	Já para os dados de movimento, foram coletadas as seguintes informações:
-	Coordenada X: refere-se ao pixel atual da aplicação no eixo X. 
-	Coordenada Y: refere-se ao pixel no eixo Y.
-	Distância: refere-se a distância (em cm) em cada um dos pontos das coordenadas X e Y.
-	Velocidade: refere-se à velocidade (em cm/s) em cada um dos pontos X e Y.
-	Aceleração: refere-se à aceleração (em cm/s²) em cada um dos pontos X e Y.

# Video Demonstrativo da Aplicação

O seguinte link exibe um video da aplicação na prática sendo utilizada em crianças: https://drive.google.com/file/d/1fBrpupD5eietuojrGEz1rdTvSG1HJ688/view?usp=sharing
