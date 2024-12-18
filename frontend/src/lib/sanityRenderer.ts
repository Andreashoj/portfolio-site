// src/lib/sanityRenderer.ts
// src/lib/sanityRenderer.ts
import { toHTML } from '@portabletext/to-html'
import Prism from 'prismjs'
import 'prismjs/components/prism-typescript'

export function renderContent(blocks: any) {
    const html = toHTML(blocks, {
        components: {
            types: {
                code: ({ value }) => {
                    const highlighted = Prism.highlight(
                        value.code,
                        Prism.languages.typescript,
                        'typescript'
                    )
                    return `
                        <div class="code-window">
                            <div class="code-header">
                                <div class="window-buttons">
                                    <span class="close"></span>
                                    <span class="minimize"></span>
                                    <span class="maximize"></span>
                                </div>
                                <div class="tab">
                                    <span class="filename">${value.filename}</span>
                                </div>
                                <span class="language">${value.language}</span>
                            </div>
                            <pre class="line-numbers"><code class="language-typescript">${highlighted}</code></pre>
                        </div>
                            `
                }
            }
        }
    })
    return html
}