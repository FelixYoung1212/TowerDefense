import os
import sys

def add_conditional_compilation_simple(directory, extensions=None):
    """简化版本，仅处理核心逻辑"""
    if extensions is None:
        extensions = ['.cs', '.cpp', '.c', '.h', '.hpp', '.js', '.ts', '.java', '.py']
    
    start_directive = "#if !ADDRESSABLES_SUPPORT"
    end_directive = "#endif"
    
    for root, dirs, files in os.walk(directory):
        for file in files:
            if any(file.endswith(ext) for ext in extensions):
                filepath = os.path.join(root, file)
                
                try:
                    with open(filepath, 'r', encoding='utf-8') as f:
                        content = f.read()
                    
                    # 检查是否已添加
                    lines = content.splitlines(keepends=True)
                    if not lines:
                        continue
                    
                    need_start = not lines[0].strip().startswith(start_directive)
                    need_end = not lines[-1].strip().startswith(end_directive)
                    
                    if need_start or need_end:
                        # 构建新内容
                        new_content = ""
                        if need_start:
                            new_content += start_directive + '\n'
                        
                        new_content += content
                        
                        if need_end:
                            if content and not content.endswith('\n'):
                                new_content += '\n'
                            new_content += end_directive + '\n'
                        
                        with open(filepath, 'w', encoding='utf-8') as f:
                            f.write(new_content)
                        
                        print(f"已处理: {filepath}")
                        
                except Exception as e:
                    print(f"跳过 {filepath}: {e}")

# 使用示例
if __name__ == "__main__":
    # 指定要处理的目录
    target_dir = sys.argv[1]  # 修改为你的目录
    
    if os.path.exists(target_dir):
        add_conditional_compilation_simple(target_dir)
        print("任务完成！")
    else:
        print(f"目录不存在: {target_dir}")