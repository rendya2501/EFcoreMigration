# MigrationsBundleConsoleAppExample

ConsoleアプリにおけるEFCoreMigrationBundle生成検証プロジェクト  

- Contextクラスに接続情報をDIする方法の検証  
  →公式サンプルの通りにやればよろしい。  
   DIのやり方にも形式があるようで、それから外れた場合はエラーとなり、bundleを生成できない。  
- 接続情報を埋め込んだ状態でbundleを生成した場合、appsetting.jsonのrequire警告が出るか検証  
  →出なかった。  
- 埋め込んだ接続情報はbundle後も有効か検証  
  →有効であった。  

- 参考  
  - [Introduction to Migration Bundles - What can they do the migration scripts don't?](https://www.youtube.com/watch?v=mBxSONeKbPk)  
