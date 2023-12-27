using System.IO; //build를 위함
using UnityEditor; //User Editor 사용을 위함
using UnityEditor.Experimental;

public class AssetBundleBuildManager
{
    [MenuItem("MyTool/Asset Bundle Build")]
    public static void AssetBundleBuild()
    {
        //현재 경로 하위 Bundle 폴더
        string directory = "./Bundle";

        //경로가 존재하지 않는 경우 경로 생성
        if (!Directory.Exists(directory)){
            Directory.CreateDirectory(directory);
        }

        //인자: 경로, 에셋번들 옵션(압축방법), 타겟 플랫폼
        BuildPipeline.BuildAssetBundles(directory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        //디버깅(확인)
        EditorUtility.DisplayDialog("에셋 번들 빌드", "에셋 번들 빌드를 완료했습니다.", "완료");
    }
}
