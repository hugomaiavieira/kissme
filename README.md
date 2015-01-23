# Kiss me

## Sumário

Alice conhece Hugo e vai conquistá-lo aos poucos. A cada fase de suas vidas, irá fazer com que ele a ame cada vez mais até que ele a peça em casamento.

## Gameplay

O objetivo é conquistar Hugo para que ele faça o pedido de casamento. Para isso, Alice irá soltar um beijo e deve fazer com que ele chegue à Hugo e aumente seu nível de conquista. 

Alice e Hugo são apenas NPCs, ou seja, serão apenas imagens/animações. O personagem jogável é o beijo que será representado por um coração alado. 

Alice aparece no início de cada fase, no canto esquerdo da tela e solta um beijo. O "Smack" vira o coração alado. 

O objetivo é fazer o coração atravessar a fase e chegar à Hugo que vai estar no final. Ao receber o beijo, Hugo é animado com um sorriso e enche a barra de conquista no percentual de fases completadas.

Ao completar a barra de conquista, aparece a frase "Quer casar comigo?" e dois botões, ambos bom a palavra "Sim", não dando opção para dizer não! =)

Caso do personagem ser atingido pelo inimigo, parece a frase "Tente novamente, não desista do amor da sua vida" e a fase é reiniciada.

O jogo será no estilo [flappy bird](https://www.youtube.com/watch?v=YHH2101OFfI) no sentido de movimentação da cena e do personagem. Contudo seria para desviar de inimigos aleatórios na cena que vem em sua direção.

## Fases

### Como nos conhecemos

Nos conhecemos na casa de Tia Soninha. Alice chegou com Brigite (sua cadelinha salsichinha marrom) no colo. Eu estava jogando futebol com meus primos.

#### Animação inicial

Alice vai estar com Brigite no colo e vai soltar o beijo.

#### Animação final

Hugo vai estar sem camisa, com o pé em cima de uma bola até receber o beijo. Os dois aparecem na tela, levantam a mão em comprimento e aparece um balãozinho "Oi" para ambos.

**Mensagem**: TODO

#### Cenário

O cenário a quadra de futebol, ou seja, um muro baixo, de cor verde, com uma grade com fundo azul representando o céu.

#### Inimigos

- bolas de futebol variadas


### Primeiro beijo

O primeiro beijo foi no cinema. Vimos o filme "O homem que desafiou o diabo".Estávamos vendo o filme e em um certo momento, peguei a mão dela, coloquei no meu peito e falei "Olha como meu coração está batendo rápido" e em seguida demos nosso primeiro beijo.

Obs1:Tinha um velho sentado sozinho e rindo muito. Isso ficou marcado pra gente, pois ficamos comentando do velho.

Obs2: Sempre que vou ao cinema, compro a bala "mentos: the freshmaker".

#### Animação inicial

Alice vai estar em uma cadeira sem ninguém ao lado e vai soltar o beijo.

#### Animação final

Hugo vai estar sentado sozinho em outra cadeira até receber o beijo. Hugo aparece ao lado de Alice, coloca a mão dela no peito dele e aparece um balãozinho com a frase "Olha como meu coração está batendo rápido" e os dois dão um beijinho.

**Mensagem**: TODO

#### Cenário

O cenário é um cinema, apenas as cadeiras. Podemos colocar o velho rindo em uma das cadeiras.

#### Inimigos

- sacos de pipoca
- pacotes de mentos
- diabinhos


### Faculdade

A faculdade é um marco para nós dois. "Penamos" muito para nos formar e o fim da faculdade é uma etapa muito importante para a entrada de fato na vida adulta.

#### Animação inicial

Alice estará sentada em uma carteira de sala de aula e vai soltar o beijo.

#### Animação final

Hugo estará sentado em um computador até receber o beijo. Ambos aparecem de beca, com o canudo na mão e dão um beijinho. A beca de Alice tem a faixa verde, a de Hugo azul.

**Mensagem**: TODO

#### Cenário

O cenário é uma sala de aula, apenas carteiras

#### Inimigos

- livros

### Finalização

Após a última fase, vai entrar a animação de um avião saindo do Brasil e pousando em Aruba. Ai vai mostrar no quarto do hotel a cena que estará acontecendo no momento, Hugo em pé ao lado de Alice que vai estar sentada jogando no celular. Vai dar um zoom na tela do celular e, que vai virar a tela do Jogo com a pergunta "Quer casar comigo?" e dois botões, ambos bom a palavra "Sim", não dando opção para dizer não! =)

---

## Desenvolvimento

O jogo tem várias [câmeras](http://unity3d.com/learn/tutorials/modules/beginner/graphics/cameras):

  - Animação: exibe as animações iniciais e finais de cada level
  - Dinâmica: exibe os objetos dinâmicos, como Player e Inimigos
  - Estática: exibe os objetos estáticos como Backgound e Floor
  - Principal: exibe tudo

As câmeras são controladas via script. A Estática sempre será exibida, enquanto a dinâmica aparece apenas quando a de animação não está ativa, e vice-versa.

### Movimentar o offset de backgrounds

Adicionar a imagem dentro da pasta Textures com os seguitnes parâmtros:

  - Texture type: Texture
  - Wrap Mode: Repeat
  - Format: Truecolor

Dentro da pasta Material, criar um material com o shader Unlit/Texture e selecionar também a textura criada no passo anterior.

No GameObject, adicionar os componentes:

  - Mesh -> Mesh Filter do tipo Quad.
  - Mesh -> Mesh Render, colocando como material, o Material criado anteriormente

O GameObject também terá que ter um componente script com o script MoveOffset abaixo:


    using UnityEngine;
    using System.Collections;
    
    public class MoveOffset : MonoBehaviour {
        
        public float speed;
        Material currentMaterial;
        float offset;
        
        void Start () {
            currentMaterial = renderer.material;
        }
        
        void Update () {
            
            offset += 0.001f;
            
            currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset*speed, 0));
            
        }
    }

Ai basta setar o valor da variável speed.

### Animações e eventos

- http://www.raywenderlich.com/66523/unity-2d-tutorial-animation-controllers