# Documentação da API Meli.Interview.DistroCenter

## Introdução

A API Meli.Interview.DistroCenter fornece funcionalidades para gerenciar e consultar informações sobre centros de distribuição. Esta documentação descreve as rotas disponíveis no controlador `CentroDistribuicaoController`, permitindo a obtenção de informações sobre centros de distribuição próximos a um item específico ou por identificadores.

## Endpoints

### CentroDistribuicaoController

#### 1. Obter Centros de Distribuição Próximos a um Item

- **Descrição**: Retorna uma lista de centros de distribuição próximos a um item especificado por um filtro.
- **Método HTTP**: `GET`
- **Rota**: `/api/CentroDistribuicao/GetCentroDistribuicaoProximoItem`
- **Parâmetros de Consulta**:
  - `filter`: Objeto `CentroDistribuicaoDTO` opcional para filtrar a proximidade.
- **Resposta**:
  - Código: `200 OK`
  - Corpo: Lista de objetos `CentroDistribuicaoDTO`.

#### 2. Obter Todos os Centros de Distribuição

- **Descrição**: Retorna uma lista de todos os centros de distribuição disponíveis (dados fictícios).
- **Método HTTP**: `GET`
- **Rota**: `/api/CentroDistribuicao/GetCentroDeDistribuicao`
- **Resposta**:
  - Código: `200 OK`
  - Corpo: Lista de objetos `CentroDistribuicaoDTO`.

#### 3. Obter Centros de Distribuição por Item ID

- **Descrição**: Retorna uma lista de centros de distribuição associados a um determinado item pelo seu ID.
- **Método HTTP**: `GET`
- **Rota**: `/api/CentroDistribuicao/GetDistrosCenterByItemCDAsync/{itemId}`
  - `{itemId}`: ID do item para o qual buscar os centros de distribuição.
- **Resposta**:
  - Código: `200 OK`
  - Corpo: Lista de objetos `CentroDistribuicaoDTO`.

#### 4. Obter Centros de Distribuição por Código CD

- **Descrição**: Retorna uma lista de centros de distribuição associados a um determinado código de centro de distribuição.
- **Método HTTP**: `GET`
- **Rota**: `/api/CentroDistribuicao/GetDistrosCenterByCodigoCD/{IdCD}`
  - `{IdCD}`: Código do centro de distribuição para o qual buscar informações.
- **Resposta**:
  - Código: `200 OK`
  - Corpo: Lista de objetos `CentroDistribuicaoDTO`.

## Modelos de Dados

### CentroDistribuicaoDTO

- Estrutura do DTO não especificada, mas geralmente inclui propriedades relevantes para identificação e localização de centros de distribuição.

## Observações

- Todos os endpoints são protegidos e podem requerer autenticação apropriada.
- Os códigos de resposta indicados são os esperados para operações bem-sucedidas. Erros podem retornar códigos diferentes conforme a situação (ex.: `404 Not Found` para centros de distribuição inexistentes).
