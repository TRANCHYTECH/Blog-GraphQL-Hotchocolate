
import type { CodegenConfig } from '@graphql-codegen/cli';

const config: CodegenConfig = {
  overwrite: true,
  schema: "C:\\Users\\dntau\\source\\repos\\Blog-GraphQL-Hotchocolate\\Tranchy.Ask.Api\\schema.graphql",
  documents: "src/**/*.graphql",
  generates: {
    "src/generated/graphql.ts": {
      plugins: ["typescript-apollo-angular"]
    },
    "./graphql.schema.json": {
      plugins: ["introspection"]
    }
  }
};

export default config;
