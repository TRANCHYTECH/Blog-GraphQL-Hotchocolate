
import type { CodegenConfig } from '@graphql-codegen/cli';

const config: CodegenConfig = {
  overwrite: true,
  schema: "C:\\Users\\dntau\\source\\repos\\Blog-GraphQL-Hotchocolate\\Tranchy.Ask.Api\\schema.graphql",
  documents: 'src/**/!(*.generated).ts',
  generates: {
    "src/types.ts": {
      plugins: ['typescript']
    },
    'src/': {
      preset: 'near-operation-file',
      presetConfig: {
        extension: '.generated.ts',
        baseTypesPath: 'types.ts',
      },
      plugins: ['typescript-operations', 'typescript-apollo-angular'],
    },
    // "src/generated/graphql.ts": {
    //   plugins: ['typescript', 'typescript-operations', 'typescript-apollo-angular']
    // },
    "./graphql.schema.json": {
      plugins: ["introspection"]
    }
  }
};

export default config;
