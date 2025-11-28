
import json
import sys
import os

class LuaFileExtractor:
    def __init__(self):
        self.results = []
    
    def extract_lua_files(self, json_file_path):
        """
        从JSON文件中提取所有包含'lua/module/battle/component'路径且以.lua结尾的字段
        """
        try:
            # 读取JSON文件
            with open(json_file_path, 'r', encoding='utf-8') as file:
                data = json.load(file)
            
            # 遍历JSON对象的所有键
            for key, value in data["value"].items():
                # 检查路径是否包含指定路径且以.lua结尾
                if 'lua/module/battle/component' in key and key.endswith('.lua'):
                    #去除lua/module/battle/component/
                    path = key.replace('lua/module/battle/component/','')
                    self.results.append(path)
                    
            return True
            
        except FileNotFoundError:
            print(f"错误：文件 '{json_file_path}' 不存在")
            return False
        except json.JSONDecodeError:
            print(f"错误：文件 '{json_file_path}' 不是有效的JSON格式")
            return False
        except Exception as e:
            print(f"处理文件时发生未知错误：{str(e)}")
            return False
    
    def display_results(self):
        """显示提取结果"""
        if not self.results:
            print("未找到符合条件的Lua文件")
            return
        
        print(f"找到 {len(self.results)} 个符合条件的Lua文件：")
        print("=" * 60)
        
        for i, item in enumerate(self.results, 1):
            print(f"{i}. 文件路径: {item}")
            print("-" * 40)
    
    def save_results(self, output_file='lua_files_result.json'):
        """将结果保存到JSON文件"""
        try:
            with open(output_file, 'w', encoding='utf-8') as file:
                json.dump(self.results, file, ensure_ascii=False, indent=2)
            print(f"结果已保存到: {output_file}")
            return True
        except Exception as e:
            print(f"保存文件时出错：{str(e)}")
            return False
    
    def get_full_paths(self):
        """返回完整路径列表"""
        return [item for item in self.results]

def main():
    """主函数"""
    # 从命令行参数获取JSON文件路径，如果没有则使用默认路径
    if len(sys.argv) > 1:
        json_file_path = sys.argv[1]
    else:
        json_file_path = 'data.json'
    
    # 创建提取器实例
    extractor = LuaFileExtractor()
    
    # 检查文件是否存在
    if not os.path.exists(json_file_path):
        print(f"错误：文件 '{json_file_path}' 不存在")
        print("使用方法: python lua_file_extractor.py <json文件路径>")
        return
    
    # 提取Lua文件
    print(f"正在处理文件: {json_file_path}")
    success = extractor.extract_lua_files(json_file_path)
    
    if success:
        # 显示结果
        extractor.display_results()
        
        # 保存结果
        extractor.save_results()
        
        # 可选：获取特定格式的结果
        print(f"\n仅文件名列表: {extractor.get_full_paths()}")
        
        # 统计信息
        print(f"\n统计信息:")
        print(f"- 总文件数: {len(extractor.results)}")
        
        # 按目录分组统计
        dir_count = {}
        for item in extractor.results:
            dir_path = os.path.dirname(item)
            dir_count[dir_path] = dir_count.get(dir_path, 0) + 1
        
        print(f"- 涉及目录数: {len(dir_count)}")
        for dir_path, count in dir_count.items():
            print(f"  {dir_path}: {count} 个文件")

if __name__ == "__main__":
    main()