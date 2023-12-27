using System.IO; //build�� ����
using UnityEditor; //User Editor ����� ����
using UnityEditor.Experimental;

public class AssetBundleBuildManager
{
    [MenuItem("MyTool/Asset Bundle Build")]
    public static void AssetBundleBuild()
    {
        //���� ��� ���� Bundle ����
        string directory = "./Bundle";

        //��ΰ� �������� �ʴ� ��� ��� ����
        if (!Directory.Exists(directory)){
            Directory.CreateDirectory(directory);
        }

        //����: ���, ���¹��� �ɼ�(������), Ÿ�� �÷���
        BuildPipeline.BuildAssetBundles(directory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        //�����(Ȯ��)
        EditorUtility.DisplayDialog("���� ���� ����", "���� ���� ���带 �Ϸ��߽��ϴ�.", "�Ϸ�");
    }
}
