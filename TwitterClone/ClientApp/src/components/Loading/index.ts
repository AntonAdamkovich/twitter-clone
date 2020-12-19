import { connect } from 'react-redux';

import Loading from './_Loading';
import selector from './selector';

export default connect(selector)(Loading);
