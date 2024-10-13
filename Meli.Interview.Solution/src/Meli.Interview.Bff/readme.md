# Documentação da API Meli.Interview.BFF

## Introdução

A API Meli.Interview.BFF serve como um ponto de unificação para as funcionalidades das APIs `Meli.Interview.Express` e `Meli.Interview.DistroCenter`. Ela fornece uma interface simplificada para operações de produtos, pedidos e centros de distribuição, otimizando a interação para aplicações frontend.

## Endpoints

### Produtos

#### 1. Cadastrar Produto

- **Descrição**: Cadastra um novo produto no sistema.
- **Método HTTP**: `POST`
- **Rota**: `/api/bff/produto`
- **Corpo da Requisição**: 
  - Tipo: `ProdutoDTO`
  - Exemplo:
    ```json
    {
      "nome": "Produto Exemplo",
      "preco": 100.0,
      "descricao": "Descrição do produto exemplo"
    }
    ```
- **Resposta**:
  - Código: `200 OK`
  - Corpo: Objeto `Produto` criado.

#### 2. Consultar Produtos

- **Descrição**: Retorna uma lista de todos os produtos cadastrados.
- **Método HTTP**: `GET`
- **Rota**: `/api/bff/produto`
- **Resposta**:
  - Código: `200 OK`
  - Corpo: Lista de objetos `Produto`.

### Pedidos

#### 1. Processar Pedido

- **Descrição**: Processa um novo pedido e determina o centro de distribuição mais próximo para cada item.
- **Método HTTP**: `POST`
- **Rota**: `/api/bff/pedido`
- **Corpo da Requisição**: 
  - Tipo: `PedidoDTO`
  - Exemplo:
    ```json
    {
      "clienteId": 1,
      "produtos": [
        {
          "produtoId": 101,
          "quantidade": 2
        },
        {
          "produtoId": 102,
          "quantidade": 1
        }
      ],
      "enderecoEntrega": "Rua Exemplo, 123, Cidade, Estado"
    }
    ```
- **Resposta**:
  - Código: `200 OK`
  - Corpo: Objeto `Pedido` processado com detalhes dos centros de distribuição.

### Centros de Distribuição

#### 1. Obter Centros de Distribuição Próximos a um Item

- **Descrição**: Retorna uma lista de centros de distribuição próximos a um item especificado.
- **Método HTTP**: `GET`
- **Rota**: `/api/bff/centro-distribuicao/proximo-item`
- **Parâmetros de Consulta**:
  - `filter`: Objeto `CentroDistribuicaoDTO` opcional para filtrar a proximidade.
- **Resposta**:
  - Código: `200 OK`
  - Corpo: Lista de objetos `CentroDistribuicaoDTO`.

#### 2. Obter Centros de Distribuição por Item ID

- **Descrição**: Retorna uma lista de centros de distribuição associados a um determinado item pelo seu ID.
- **Método HTTP**: `GET`
- **Rota**: `/api/bff/centro-distribuicao/por-item/{itemId}`
  - `{itemId}`: ID do item para o qual buscar os centros de distribuição.
- **Resposta**:
  - Código: `200 OK`
  - Corpo: Lista de objetos `CentroDistribuicaoDTO`.

## Modelos de Dados

### ProdutoDTO

- `nome`: string
- `preco`: decimal
- `descricao`: string

### PedidoDTO

- `clienteId`: int
- `produtos`: lista de objetos contendo:
  - `produtoId`: int
  - `quantidade`: int
- `enderecoEntrega`: string

### CentroDistribuicaoDTO

- Estrutura do DTO não especificada, mas geralmente inclui propriedades relevantes para identificação e localização de centros de distribuição.

## Observações

- Todos os endpoints são projetados para fornecer uma interface unificada e otimizada para aplicações frontend.
- A API pode requerer autenticação apropriada para acessar determinados endpoints.
- Os códigos de resposta indicados são os esperados para operações bem-sucedidas. Erros podem retornar códigos diferentes conforme a situação (ex.: `404 Not Found` para recursos inexistentes).
