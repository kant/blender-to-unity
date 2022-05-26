import importlib
from sys import path
import timeit
path.append('E:\\repos\\blender-to-unity\\02-bpy')
import ublend
importlib.reload(ublend.ops)
importlib.reload(ublend.data)

FILE_NAME = "blender_export.ublend"
UNITY_PROJECT = 'E:\\repos\\blender-to-unity\\blender-to-unity\\'
UNITY_EXPORT = UNITY_PROJECT + 'Assets\\01-scripts\\ublend\\' + FILE_NAME


class File():
    @staticmethod
    def save_to_unity(filepath, ublend_json):
        ''' Save the UBlend Json to Unity '''
        with open(filepath, 'w') as f:
            f.write(ublend_json)
        return


ublenddata = ublend.ops.get_u_data()
json = ublenddata.tojson()
print(json)
File.save_to_unity(UNITY_EXPORT, ublenddata.tojson())
